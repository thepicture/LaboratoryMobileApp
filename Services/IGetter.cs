using System.Collections.Generic;

namespace LaboratoryMobileApp.Services
{
    public interface IGetter<T>
    {
        IEnumerable<T> Get();
    }
}