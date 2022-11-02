using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul3.Models
{
    public class Ispit
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public Predmet Predmet { get; set; }//Polje za sami predmet, tipa Predmet klase;
        [ForeignKey("PredmetID")]//Ovo nije mandatory, jer ce Entity framework sam ovo ispod da prepozna ali je dobra praksa;
        public int PredmetID { get; set; }//FK na predmet

        public DateTime DatumIspita { get; set; }
    }
}
