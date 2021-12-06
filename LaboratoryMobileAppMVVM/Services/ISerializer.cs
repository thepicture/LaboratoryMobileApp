namespace LaboratoryMobileAppMVVM.Services
{
    public interface ISerializer<T> where T : class
    {
        void Serialize(T entity);
    }
}
