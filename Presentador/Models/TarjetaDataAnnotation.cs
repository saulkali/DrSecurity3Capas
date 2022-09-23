using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entidades;

namespace Presentador.Model
{
    [MetadataType(typeof(TarjetaDataAnnotation))]
    public partial class Tarjeta{

    }
    public class TarjetaDataAnnotation
    {
        public int id { get; set; }
        [Required]
        public string noTarjeta { get; set; }
        [Required(ErrorMessage = " el campo {0} es requerido")]
        public string fecha { get; set; }
        [Required(ErrorMessage = " el campo {0} es requerido")]
        public string ccv { get; set; }
        [Required(ErrorMessage = " el campo {0} es requerido")]
        public string nombreTitular { get; set; }
        public Nullable<int> idUsuario { get; set; }
    }
}
