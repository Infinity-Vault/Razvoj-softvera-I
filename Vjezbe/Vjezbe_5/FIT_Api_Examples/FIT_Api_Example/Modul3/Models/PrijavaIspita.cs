using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul3.Models
{
    public class PrijavaIspita
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumPrijave { get; set; }

        public Student Student { get; set; }//Property tipa Student;
        [ForeignKey ("StudentID")]
        public int StudentID { get; set; }//FK

        public Ispit Ispit { get; set; }//Property tipa Ispit;
        [ForeignKey("IspitID")]
        public int IspitID { get; set; }//FK
    }
}
