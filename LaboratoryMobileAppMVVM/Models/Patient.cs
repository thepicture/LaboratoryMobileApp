namespace LaboratoryMobileAppMVVM.Models
{
    public class Patient
    {
        public string FullName { get; set; }
        public string PassNum { get; set; }
        public string PassSeries { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string InsuranceNumber { get; set; }
        public RequestLoginPatient LoginAndPassword { get; set; }
    }
}
