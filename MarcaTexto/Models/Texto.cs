using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcaTexto
{
    [Table("Texto")]
    public class Texto
    {
         [Display(Name = "id")]
        [Column("id")]
        public int Id { get; set; } = new int();
      

        [Display(Name = "Texto1")]
        [Column("Texto1")]
        public string? Texto1{ get; set; }


        [Display(Name = "Texto2")]
        [Column("Texto2")]

        public string Texto2 { get; set; }


    }


}
