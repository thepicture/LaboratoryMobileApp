namespace LaboratoryMobileAppMVVM.Models
{
    public class ResponseService
    {
        public ResponseService(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
