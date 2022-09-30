namespace LinkPlus_Orders_Assignment.Dtos.OrderDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public int OrderPrice { get; set; } = 0;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
