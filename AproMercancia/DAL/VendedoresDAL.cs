using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AproMercancia.DLL;


namespace AproMercancia.DAL
{
    class VendedoresDAL
    {
        ConexionDAL Conexion;
        
        public VendedoresDAL()
        {
            Conexion = new ConexionDAL();
        }
        public bool addVendedores(VendedorBLL oVendedorDLL)
        {
            return Conexion.executeCommandNoDataReturn("INSERT INTO vendedor(nombre, cedula, fecha, id_tienda) " +
                "VALUES('"+oVendedorDLL.Nombre+"', "+oVendedorDLL.Cedula+", '"+oVendedorDLL.Fecha+"', "+oVendedorDLL.Tienda+")");
        }
        public bool removeVendedores(VendedorBLL oVendedoresBLL)
        {
            return Conexion.executeCommandNoDataReturn("DELETE FROM vendedor " +
                "WHERE id_vendedor="+oVendedoresBLL.Referencia);
        }
        public bool updateVendedores(VendedorBLL oVendedorBLL)
        {
            return Conexion.executeCommandNoDataReturn("UPDATE vendedor SET nombre='" + oVendedorBLL.Nombre +
                "', cedula=" + oVendedorBLL.Cedula + ", id_tienda="+oVendedorBLL.Tienda+" WHERE id_vendedor="+oVendedorBLL.Referencia);
        }
        public DataSet ShowEmpleados()
        {
            SqlCommand Sentencia = new SqlCommand("SELECT vendedor.id_vendedor, vendedor.nombre, vendedor.cedula, vendedor.fecha, tienda.ciudad, tienda.direccion FROM vendedor INNER JOIN tienda ON vendedor.id_tienda = tienda.id_tienda");
            return Conexion.ExecuteSentences(Sentencia);
        }
    }
}

