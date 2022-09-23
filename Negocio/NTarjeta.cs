using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;

namespace Negocio
{
    public class NTarjeta
    {
        
        STarjeta sTarjetas = new STarjeta();

        public Tarjeta ObtenerTarjetaPorId(int id) => sTarjetas.ObtenerTarjetaPorId(id);
        public List<Tarjeta> ObtenerTarjetas() => sTarjetas.ObtenerTarjetas();
        public bool CrearTarjeta(Tarjeta tarjeta) => sTarjetas.CrearTarjeta(tarjeta);
        public bool EliminarTarjeta(int id) => sTarjetas.EliminarTarjeta(id);
        public bool EditarTarjeta(int id, Tarjeta tarjeta) =>sTarjetas.Editartarjeta(id,tarjeta);
        

    }
}
