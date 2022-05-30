namespace Pizzaroti.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string Email { get; set; } = "gdennar@yahoo.co.uk";
        public string ImageTitle { get; set; }

    }
}
