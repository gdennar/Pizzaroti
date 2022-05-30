namespace Pizzaroti.Models
{
    public class TransactionModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int PizzaPrice { get; set; }
        public string PizzaName { get; set; }

        public string ImageTitle { get; set; }
        public string Email { get; set; } = "gdennar@yahoo.co.uk";
        public string TrxRef { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Status { get; set; }

    }
}
