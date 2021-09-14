using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSucursal
    {
        public int id { get; set; }
        public string Sucursal { get; set; }
        public string Ubicacion { get; set; }
        public int TelefonoSucursal { get; set; }
        public bool EstadoSucursal { get; set; }

        public DSucursal()
        {

        }
        public DSucursal(string Sucursal, string Ubicacion, int TelefonoSucursal, bool EstadoSucursal)
        {
            this.Sucursal = Sucursal;
            this.Ubicacion = Ubicacion;
            this.TelefonoSucursal = TelefonoSucursal;
            this.EstadoSucursal = EstadoSucursal;
        }
        SqlConnection SqlCon = new SqlConnection();
        public bool InsertarSucursal(DSucursal objd)
        {
            SqlCon.ConnectionString = DConexion.Cn;
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlCon;
            cmd.CommandText = "sp_insertarsucursal";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sucursal", objd.Sucursal);
            cmd.Parameters.AddWithValue("@Ubicacion", objd.Ubicacion);
            cmd.Parameters.AddWithValue("@TelefonoSucursal", objd.TelefonoSucursal);
            cmd.Parameters.AddWithValue("@EstadoSucursal", objd.EstadoSucursal);
            if (cmd.ExecuteNonQuery() == 1)
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                return true;
            }
            else
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                return false;
            }
        }
        public bool ActualizarSucursal(DSucursal objd)
        {
            SqlCon.ConnectionString = DConexion.Cn;
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlCon;
            cmd.CommandText = "sp_actualizarsucursal";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", objd.id);
            cmd.Parameters.AddWithValue("@Sucursal", objd.Sucursal);
            cmd.Parameters.AddWithValue("@Ubicacion", objd.Ubicacion);
            cmd.Parameters.AddWithValue("@TelefonoSucursal", objd.TelefonoSucursal);
            cmd.Parameters.AddWithValue("@EstadoSucursal", objd.EstadoSucursal);
            if (cmd.ExecuteNonQuery() == 1)
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                return true;
            }
            else
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                return false;
            }
        }
        public bool EliminarSucursal(DSucursal objd)
        {
            SqlCon.ConnectionString = DConexion.Cn;
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlCon;
            cmd.CommandText = "sp_eliminarsucursal";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", objd.id);
            if (cmd.ExecuteNonQuery() == 1)
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                return true;
            }
            else
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                return false;
            }
        }
        public DataTable MostrarSucursal()
        {           
            try
            {
                //SqlCon.ConnectionString = DConexion.Cn;         
                SqlCommand cmd = new SqlCommand("sp_listarsucursal", SqlCon);
                SqlDataReader LeerFilas;
                DataTable Tabla = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                LeerFilas = cmd.ExecuteReader();
                Tabla.Load(LeerFilas);
                LeerFilas.Close();
                return Tabla;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            
        }
    }
}
