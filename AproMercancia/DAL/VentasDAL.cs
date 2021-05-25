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
    class VentasDAL
    {
        ConexionDAL Conexion;
        public VentasDAL()
        {
            Conexion = new ConexionDAL();
        }
        public bool addVentas(VentasBLL oVentasBLL)
        {
            return Conexion.executeCommandNoDataReturn("INSERT INTO detalle_ventas(referencia_prod, id_vendedor, cantidad) " +
                "VALUES ("+oVentasBLL.Producto+", "+oVentasBLL.Empleado+", "+oVentasBLL.Cantidad+")");
        }
        public bool Eliminar(VentasBLL oVentasBLL)
        {
            return Conexion.executeCommandNoDataReturn("DELETE FROM detalle_ventas " +
                "WHERE referencia_Prod=" + oVentasBLL.Producto+" and id_vendedor="+oVentasBLL.Empleado);
           
        }
        public DataSet ShowVentas()
        {
            SqlCommand Sentencia = new SqlCommand("SELECT producto.nombre, vendedor.nombre, detalle_ventas.cantidad FROM detalle_ventas INNER JOIN producto ON detalle_ventas.referencia_prod = producto.referencia_prod INNER JOIN vendedor ON detalle_ventas.id_vendedor=vendedor.id_vendedor;");
            return Conexion.ExecuteSentences(Sentencia);
        }
    }
}
