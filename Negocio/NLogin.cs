using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;
namespace Negocio
{
    public class NLogin
    {

        SUsuarios sUsuarios = new SUsuarios();

        public Usuario Entrar(string correo, string contrasena) => sUsuarios.Entrar(correo,contrasena);
    }
}
