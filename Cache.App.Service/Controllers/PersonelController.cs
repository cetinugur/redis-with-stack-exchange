using Cache.App.Service.Models;
using Cache.App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cache.App.Service.Controllers
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
