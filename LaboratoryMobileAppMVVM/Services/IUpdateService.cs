namespace LaboratoryMobileAppMVVM.Services
{
    public interface IUpdateService<T> where T : class
    {
        bool IsSuccessUpdate(T entity);
        T GetUpdatedObject();
    }
}
