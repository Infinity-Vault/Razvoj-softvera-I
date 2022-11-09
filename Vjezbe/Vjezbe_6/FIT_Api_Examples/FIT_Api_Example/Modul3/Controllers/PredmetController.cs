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
                ECTS = predmet.ECTS,//Preuzmemo ECTS
                OcjenaPredmeta=0//Postavimo default vrijednost ocjene na 0;
            };

            _dbContext.Add(noviPredmet);
            _dbContext.SaveChanges();
            return noviPredmet;
        }

        [HttpGet] //Tip metode koju kreiramo;
        public List<Predmet> GetAll(string nazivPredmeta, float minProsjek)
        {
            var data = _dbContext.Predmeti//Idemo u listu predmeta (tabelu u bazi);
                .Where(predmet=> predmet.Naziv.ToLower().Contains(nazivPredmeta.ToLower())
                //U donjem Average ukoliko se vrati null, posto ocjene mogu biti null u bazi, zamijeniti
                //cemo to sa 0;
                && (_dbContext.Predmeti.Average(predmetProsjek=>predmetProsjek.OcjenaPredmeta)??0)<=minProsjek) //Uzmemo predmete kod kojih je ime filtrirano sa ulaznim parametrom i cija je prosjecna vrijednost <= od ulaznog parametra;
                .OrderBy(predmet => predmet.ID)//Poredamo prema ID-u predmeta;
                .Select(predmet => new Predmet() 
                {
                    ID = predmet.ID,
                    Naziv = predmet.Naziv,
                    ECTS=predmet.ECTS,
                    OcjenaPredmeta=predmet.OcjenaPredmeta
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
