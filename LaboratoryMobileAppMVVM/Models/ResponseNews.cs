namespace LaboratoryMobileAppMVVM.Models
{
    public class ResponseNews
    {
        public string NewsText { get; set; }
        public byte[] ImagePreview { get; set; }
        public int Id { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public string PublicationDate { get; set; }
    }
}
