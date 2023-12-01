namespace OrderModels
{
    public class Order
    {
        public int Id { get; set; }
        public string BookID { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
    }
}
