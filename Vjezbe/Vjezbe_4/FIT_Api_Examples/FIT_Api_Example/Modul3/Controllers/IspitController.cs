using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class IspitController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public IspitController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost] //Tip metode koju kreiramo;
        public Ispit Add([FromBody] IspitDTO ispit)
        {
            var noviIspit = new Ispit //Kreiramo novi ispit
            {
                Naziv = ispit.Naziv, //Preuzmemo naziv
                DatumIspita=DateTime.Now,//Datum postavimo na trenutni
                PredmetID=ispit.Predmet.ID,//Preuzmemo ID
                Predmet=ispit.Predmet,//Uzmemo predmet kao objekat;                
            };

            _dbContext.Add(noviIspit);
            _dbContext.SaveChanges();
            return noviIspit;
        }

        [HttpGet] //Tip metode koju kreiramo;
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Ispiti//Idemo u listu ispita (tabelu u bazi);
                .OrderBy(ispit => ispit.DatumIspita)//Poredamo prema datumu;
                .Select(ispit => new CmbStavke()
                {
                    id = ispit.ID,
                    opis = ispit.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
