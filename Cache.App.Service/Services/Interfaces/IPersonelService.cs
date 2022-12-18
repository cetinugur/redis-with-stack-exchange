using Cache.App.Service.Models;

namespace Cache.App.Service.Services.Interfaces
{
    public interface IPersonelService
    {
        IEnumerable<Personel> GetList();

        Personel? GetOne(int jobCode);
    }
}
