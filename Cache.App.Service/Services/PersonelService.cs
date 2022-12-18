using Cache.App.Service.Models;
using Cache.App.Service.Services.Interfaces;
using Cache.Core.Attributes;

namespace Cache.App.Service.Services
{
    public class PersonelService : IPersonelService
    {
        private static readonly string[] Names = new[]{
        "Uğur", "Ahmet", "Mehmet", "Yusuf", "Murat", "Ali", "Okan", "Samet", "Semih", "Mahmut"};

        private static readonly string[] Surnames = new[]{
        "Güler", "Gelmez", "Ayar", "Çetin", "Çalışkan", "Metin", "Yalçın", "Çalışkanoğlu", "Çekmez", "Çeker"};

        private static readonly string[] Jobs = new[]{
        "Müdür", "İşçi", "Reklamcı", "Esnaf", "Kahveci", "Barmen", "Oto yıkamacı", "Tamirci", "Duvar ustası", "Sürücü"};

        private static readonly int[] JobCodes = new[] { 1, 2, 3, 4, 5, 6 };

        public IEnumerable<Personel> GetList()
        {
            return Enumerable.Range(1, 5).Select(index => new Personel
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Surname = Surnames[Random.Shared.Next(Surnames.Length)],
                Job = Jobs[Random.Shared.Next(Jobs.Length)],
                JobCode = JobCodes[Random.Shared.Next(JobCodes.Length)],
            }).ToArray();
        }

        [Cache(Core.Enums.TTLTypes.InDays, 120)]
        public Personel? GetOne(int jobCode) => GetList().FirstOrDefault(x => x.JobCode == jobCode);
    }
}
