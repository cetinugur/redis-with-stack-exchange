using Cache.Imp.Models;
using Cache.Imp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cache.Imp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService personelService;

        public PersonelController(IPersonelService personelService)
        {
            this.personelService = personelService;
        }

        [HttpGet(Name = "GetPersonels")]
        public IEnumerable<Personel> Get()
        {
            return personelService.Get();
        }
    }
}
