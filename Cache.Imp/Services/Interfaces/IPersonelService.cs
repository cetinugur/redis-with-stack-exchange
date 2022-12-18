using Cache.Imp.Models;

namespace Cache.Imp.Services.Interfaces
{
    public interface IPersonelService
    {
        IEnumerable<Personel> Get();
    }
}
