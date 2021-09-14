using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTrabajadores
    {
        public int id { get; set; }
        public int idSucursal { get; set; }
        public int idLogueo { get; set; }
        public int CoditoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int TelefonoUsuario { get; set; }
        public int CelularUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public Boolean EstadoUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
