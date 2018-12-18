namespace Shop.Models
{
    public class OrderExtended
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Company { get; set; }
        public string Year { get; set; }
        public float Price { get; set; }
        public string OrderName { get; set; }
        public string Address { get; set; }
    }
}