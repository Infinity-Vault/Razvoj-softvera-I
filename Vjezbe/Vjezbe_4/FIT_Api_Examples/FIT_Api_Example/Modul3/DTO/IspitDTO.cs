using FIT_Api_Example.Modul3.Models;

namespace FIT_Api_Example.Modul2.Controllers
{
    public class IspitDTO
    {
        //Ono sto kreiramo od propertija u ovoj klasi je ono sto ce biti vidljivo u body-u requesta;
        public string Naziv { get; set; }
        public Predmet Predmet { get; set; }
    }
}