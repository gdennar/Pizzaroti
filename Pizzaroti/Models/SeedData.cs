using Microsoft.EntityFrameworkCore;
using Pizzaroti.Data;

namespace Pizzaroti.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PizzaModelContext(serviceProvider.GetRequiredService<DbContextOptions<PizzaModelContext>>()))
            {
                if (context.PizzaModel.Any())
                {
                    return;
                }
                context.PizzaModel.AddRange(
            new PizzasModel()
            {
                ImageTitle = "Margerita",
                PizzaName = "Margerita",
                BasePrice = 2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice = 2500
            },

            new PizzasModel()
            {
                ImageTitle = "MeatFeast",
                PizzaName = "MeatFeast",
                BasePrice = 2,
                TomatoSauce = true,
                Cheese = true,
                Beef = true,
                FinalPrice = 3000
            },
            new PizzasModel()
            {
                ImageTitle = "Carbonara",
                PizzaName = "Carbonara",
                BasePrice = 2,
                TomatoSauce = true,
                Cheese = true,
                Ham = true,
                FinalPrice = 3500
            },
            new PizzasModel()
            {
                ImageTitle = "Vegetarian",
                PizzaName = "Vegetarian",
                BasePrice = 2,
                TomatoSauce = true,
                Cheese = true,
                Mushroom = true,
                FinalPrice = 3500
            },
            new PizzasModel()
            {
                ImageTitle = "Bolognese",
                PizzaName = "Bolognese",
                BasePrice = 2,
                TomatoSauce = true,
                Cheese = true,
                Ham = true,
                Beef = true,
                FinalPrice = 4000
            },
             new PizzasModel()
             {
                 ImageTitle = "Hawaiian",
                 PizzaName = "Hawaiian",
                 BasePrice = 2,
                 TomatoSauce = true,
                 Cheese = true,
                 Tuna = true,
                 Pineapple = true,
                 FinalPrice = 5500
             },
             new PizzasModel()
             {
                 ImageTitle = "Pepperoni",
                 PizzaName = "Pepperoni",
                 BasePrice = 2,
                 TomatoSauce = true,
                 Cheese = true,
                 Peperoni = true,
                 Ham = true,
                 FinalPrice = 2500
             },
             new PizzasModel()
             {
                 ImageTitle = "Mushroom",
                 PizzaName = "Mushroom",
                 BasePrice = 2,
                 TomatoSauce = true,
                 Cheese = true,
                 Mushroom = true,
                 Ham = true,
                 Pineapple = true,
                 FinalPrice = 5500
             },
             new PizzasModel()
             {
                 ImageTitle = "Seafood",
                 PizzaName = "Seafood",
                 BasePrice = 2,
                 TomatoSauce = true,
                 Cheese = true,
                 Mushroom = true,
                 Ham = true,
                 Tuna = true,
                 FinalPrice = 8000
             });
                context.SaveChanges();
            }


        }
    }
}
