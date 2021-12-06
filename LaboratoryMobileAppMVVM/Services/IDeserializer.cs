using System.Threading.Tasks;

namespace LaboratoryMobileAppMVVM.Services
{
    public interface IDeserializer<T>
    {
        Task<T> DeserializeAsync();
    }
}
