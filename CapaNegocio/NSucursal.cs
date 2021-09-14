using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NSucursal
    {
        public static bool InsertarSucursal(string Sucursal, string Ubicacion, int TelefonoSucursal, bool EstadoSucursal)
        {
            DSucursal objd = new DSucursal();
            objd.Sucursal = Sucursal;
            objd.Ubicacion = Ubicacion;
            objd.TelefonoSucursal = TelefonoSucursal;
            objd.EstadoSucursal = EstadoSucursal;
            return objd.InsertarSucursal(objd);
        }
        public static bool ActualizarSucursal(int id, string Sucursal, string Ubicacion,int TelefonoSucursal,bool EstadoSucursal)
        {
            DSucursal objd = new DSucursal();
            objd.id = id;
            objd.Sucursal = Sucursal;
            objd.Ubicacion = Ubicacion;
            objd.TelefonoSucursal = TelefonoSucursal;
            objd.EstadoSucursal = EstadoSucursal;
            return objd.ActualizarSucursal(objd);
        }
        public static bool EliminarSucursal(int id)
        {
            DSucursal objd = new DSucursal();
            objd.id = id;
            return objd.EliminarSucursal(objd);
        }
        public static DataTable Mostrar()
        {
            return new DSucursal().MostrarSucursal();
        }
    }
}
