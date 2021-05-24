using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AproMercancia.DAL
{
    class ConexionDAL
    {
        public string CadenaConexion = "Data Source=DESKTOP-57I2ASG\\SQLEXPRESS; Initial Catalog=proyecto_mercancia; Integrated Security=True";
        SqlConnection Conexion = new SqlConnection();

        public SqlConnection EstablecerConexion()
        {
            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;
        }   
        public bool executeCommandNoDataReturn(string strComando)
        {
            try
            {                
                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strComando; 
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataSet ExecuteSentences(SqlCommand SqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlComando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = SqlComando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }


    }
}
