using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FIT_Api_Example.Modul3.Models
{
    public class Predmet
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public int ECTS { get; set; }
        public int? OcjenaPredmeta { get; set; }
    }
}
