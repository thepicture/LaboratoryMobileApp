namespace LaboratoryMobileAppMVVM.Services
{
    public interface ILoginService<T>
    {
        bool IsSuccessLogin(string login, string password);
        T GetLoginObject();
    }
}
