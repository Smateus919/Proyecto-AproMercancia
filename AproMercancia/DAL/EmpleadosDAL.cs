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
    class EmpleadosDAL
    {
        ConexionDAL Conexion;
        public EmpleadosDAL()
        {
            Conexion = new ConexionDAL();
        }
        public DataSet ShowEmpleados()
        {
            SqlCommand Sentencia = new SqlCommand("SELECT * FROM vendedor");
            return Conexion.ExecuteSentences(Sentencia);
        }
    }
}

