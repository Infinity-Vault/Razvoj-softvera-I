using FIT_Api_Example.Modul2.Models;
using FIT_Api_Example.Modul3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example
{
   public  class Ocjena
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumOcjene { get; set; }

        //Prvo kreiramo sam property tipa Student:
        public Student Student { get; set; }
        //Onda kreiramo vanski kljuc na Studenti tabelu:
        [ForeignKey ("StudentID")]
        public int StudentID { get; set; }//Naziv propertija se mora poklapati u gornjim navodnicima vanjskog kljuca;

        //Isto uradimo za drugi kljuc:

        public Predmet  Predmet { get; set; }
        [ForeignKey("PredmetID")]
        public int PredmetID { get; set; }
    }
}