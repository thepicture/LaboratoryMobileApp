namespace LaboratoryMobileAppMVVM.Services
{
    public interface IRegisterService<T> where T : class
    {
        bool IsSuccessRegister(T entity);
    }
}
