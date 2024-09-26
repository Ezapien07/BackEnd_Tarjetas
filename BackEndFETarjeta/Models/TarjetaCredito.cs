using System.ComponentModel.DataAnnotations;

namespace BackEndFETarjeta.Models
{
    public class TarjetaCredito
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string NumTarjeta { get; set; }
        [Required]
        public string FechaExp {  get; set; }
        [Required]
        public int cvv { get; set; }
    }
}
