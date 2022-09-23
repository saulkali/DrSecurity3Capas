using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;

namespace Negocio
{
    public class NUsuario
    {


        SUsuarios sUsuarios = new SUsuarios();

        public List<Usuario> ObtenerUsuarios() => sUsuarios.ObtenerUsuarios();
        public Usuario ObtenerUsuarioPorId(int id) => sUsuarios.ObtenerUsuarioPorId(id);
        public bool CrearUsuario(Usuario usuario) => sUsuarios.CrearUsuario(usuario);
        public bool EditarUsuario(int id, Usuario usuario) => sUsuarios.EditarUsuario(id, usuario);
        public bool EliminarUsuario(int id) => sUsuarios.EliminarUsuario(id);


    }
}
