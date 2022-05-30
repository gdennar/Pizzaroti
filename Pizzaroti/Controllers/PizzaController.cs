using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayStack.Net;
using Pizzaroti.Data;
using Pizzaroti.Models;
using System.Net;

namespace Pizzaroti.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly PizzaModelContext _context;
        private readonly string token;
        private PayStackApi PayStack { get; set; }


        public PizzaController(IConfiguration configuration, PizzaModelContext context)
        {
            _configuration = configuration;
            _context = context;
            token = _configuration["Payment:PaystackSK"];
            PayStack = new PayStackApi(token);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.PizzaModel.ToListAsync());
        }


        //Create Custom Pizza
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        //Create Pizza Post Call//
        [HttpPost]
        public IActionResult Create(PizzasModel pizza)
        {
            float PizzaPrice = pizza.BasePrice;

            if (pizza.TomatoSauce ) PizzaPrice += 500;
            if (pizza.Tuna) PizzaPrice += 500;
            if (pizza.Cheese) PizzaPrice += 500;
            if (pizza.Beef) PizzaPrice += 1000;
            if (pizza.Chicken) PizzaPrice += 1500;
            if (pizza.Ham) PizzaPrice += 500;
            if (pizza.Mushroom) PizzaPrice += 2500;
            if (pizza.Pineapple) PizzaPrice += 3000;
            if (pizza.Peperoni) PizzaPrice += 500;

            return RedirectToAction(nameof(Checkout), new { pizza.PizzaName, PizzaPrice, pizza.ImageTitle });
        }


        //Checkout for Get//
        [HttpGet]
        public IActionResult Checkout(string PizzaName, float PizzaPrice, string ImageTitle)
        {
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }

            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.PizzaPrice = PizzaPrice;
            pizzaOrder.ImageTitle = ImageTitle;

            _context.PizzaOrders.Add(pizzaOrder);
            _context.SaveChanges();
            return View(pizzaOrder);
        }


        public IActionResult Thankyou()
        {
            return View();
        }



        //Paystack & Checkout Post Call//
        [HttpPost]
        public async Task<IActionResult> Checkout(PizzaOrder order)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = (int)order.PizzaPrice * 100,
                Email = order.Email,
                Reference = Generate().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:65439/pizza/verify"
            };

            TransactionInitializeResponse response = PayStack.Transactions.Initialize(request);
            if (response.Status)
            {
                var transaction = new TransactionModel()
                {
                    PizzaPrice = (int)order.PizzaPrice,
                    Email = order.Email,
                    PizzaName = order.PizzaName,
                    ImageTitle = order.ImageTitle,
                    TrxRef = request.Reference,
                };
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                return Redirect(response.Data.AuthorizationUrl);
                
            }
            ViewData["error"] = response.Message;
            return View();
        }

        //Payment Get Call//
        [HttpGet]
        public IActionResult Payments()
        {
            var transactions = _context.Transactions.Where(x => x.Status == true).ToList();
            ViewData["transactions"] = transactions;
            return View();
        }

        //Verify Get//
        [HttpGet]
        public async Task<IActionResult> Verify(string reference)
        {
            TransactionVerifyResponse response = PayStack.Transactions.Verify(reference);

            if (response.Data.Status == "success")
            {
                var transaction = _context.Transactions.Where(x => x.TrxRef == reference).FirstOrDefault();
                if(transaction != null)
                {
                    transaction.Status = true;
                    _context.Transactions.Update(transaction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Thankyou));
                }
            }
            ViewData["error"] = response.Data.GatewayResponse;
            return RedirectToAction(nameof(Checkout));
        }


        public static int Generate()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(10000000, 999999999);
        }
    }
}
