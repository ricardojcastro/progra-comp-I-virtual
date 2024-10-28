using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Bloque2_Actividad1_Creando_objetos
{
    internal class db_conexion
    {
        SqlConnection miConexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();
        SqlDataAdapter miAdaptador = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public db_conexion()
        {
            miConexion.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_peliculas.mdf;Integrated Security=True";
            miConexion.Open();
        }
        public DataSet obtenerdatos()
        {
            ds.Clear();
            miComando.Connection = miConexion;
            miComando.CommandText = "SELECT * FROM Peliculas";
            miAdaptador.SelectCommand = miComando;
            miAdaptador.Fill(ds, "peliculas");

            return ds;
        }
        public string administrarPeliculas(string[] peliculas) {
            string sql = "";
            if (peliculas[0] == "Nuevo") {//accion nuevo
                sql = "INSERT INTO peliculas (titulo, autor, sinopsis, duracon, clasificacion) VALUE(+" +
                    "'" + peliculas[2] + "'," +
                    "'" + peliculas[3] + "'," +
                    "'" + peliculas[4] + "'," +
                    "'" + peliculas[5] + "',";
            }else if(peliculas[0]=="modificar")
            {
                sql = "UPDATE peliculas SET titulo='" + peliculas[2] + "', autor'" + peliculas[3] + "', " +
                    "sinopsis='" + peliculas[4] + "',duracion= '" + peliculas[5] + "' WHERE idpeliculas" + peliculas[1];
            }else if (peliculas[0]== "eliminar")
            {
                sql = "DELETE FROM peliculas WHERE idpeliculas='" + peliculas[1] + "'";
            }
            return ejecutarSQL(sql);
        }
        private string ejecutarSQL(string sql) {
            try
            {
                miComando.Connection = miConexion;
                miComando.CommandText = sql;
                return miComando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex) {
                return ex.Message;
            }

        }

        internal string administrarpeliculas(string[] datos)
        {
            throw new NotImplementedException();
        }
    }
}
    

