using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AproMercancia.BLL;
namespace AproMercancia.DAL
{
    class TiendasDAL
    {
        ConexionDAL Conexion;

        public TiendasDAL()
        {
            Conexion = new ConexionDAL();
        }
        public DataSet ShowStores()
        {
            SqlCommand Sentencia = new SqlCommand("SELECT * FROM tienda");
            return Conexion.ExecuteSentences(Sentencia);
        }
    }
}
