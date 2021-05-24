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
    class CategoriasDAL
    {
        ConexionDAL Conexion;

        public CategoriasDAL()
        {
            Conexion = new ConexionDAL;
        }
        public DataSet ShowCategories()
        {
            SqlCommand Sentencia = new SqlCommand("SELECT * FROM categoria");
            return Conexion.ExecuteSentences(Sentencia);
        }
    }
}
