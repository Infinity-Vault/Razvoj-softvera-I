using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul3.DTO;
using FIT_Api_Example.Modul3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PredmetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost] //Tip metode koju kreiramo;
        public Predmet Add([FromBody] PredmetDTO predmet)
        {
            var noviPredmet = new Predmet //Kreiramo novi ispit
            {
                Naziv = predmet.Naziv, //Preuzmemo naziv
                Sifra = predmet.Sifra,//Uzmemo sifru
                ECTS = predmet.ECTS//Preuzmemo ECTS
            };

            _dbContext.Add(noviPredmet);
            _dbContext.SaveChanges();
            return noviPredmet;
        }

        [HttpGet] //Tip metode koju kreiramo;
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Predmeti//Idemo u listu predmeta (tabelu u bazi);
                .OrderBy(predmet => predmet.ID)//Poredamo prema ID-u predmeta;
                .Select(predmet => new CmbStavke()
                {
                    id = predmet.ID,
                    opis = predmet.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
