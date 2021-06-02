using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using AproMercancia.BLL;
using AproMercancia.DLL;

namespace AproMercancia.DAL
{
    class ProductosDAL
    {
        ConexionDAL Conexion;
        
        public ProductosDAL()
        {
            Conexion = new ConexionDAL();
        }
        public bool Agregar(ProductosBLL oProductosBLL)
        {
            return Conexion.executeCommandNoDataReturn("insert into producto(nombre, valor, cant_tienda, cant_bodega, id_categoria) " +
                "VALUES ('"+oProductosBLL.Nombre+"', "+oProductosBLL.Valor+", "+oProductosBLL.cantTienda+", "+oProductosBLL.cantBodega+", "+oProductosBLL.Categoria+");");
        }
        public int Eliminar(ProductosBLL oProductosBLL)
        {
            Conexion.executeCommandNoDataReturn("DELETE FROM producto " +
                "WHERE referencia_Prod="+oProductosBLL.Referencia);
            return 1;
        }
        public int Modificar(ProductosBLL oProductosBLL)
        {
            Conexion.executeCommandNoDataReturn("UPDATE producto " +
                "SET nombre='"+oProductosBLL.Nombre+
                "', valor="+oProductosBLL.Valor+
                ", cant_tienda="+oProductosBLL.cantTienda+
                ", cant_bodega="+oProductosBLL.cantBodega+
                " WHERE referencia_Prod=" + oProductosBLL.Referencia);
            return 1;
        }
        public DataSet ShowProducts()
        {
            SqlCommand Sentencia = new SqlCommand("SELECT producto.referencia_prod, producto.nombre, producto.valor, producto.cant_tienda, producto.cant_bodega, categoria.nombre FROM producto INNER JOIN categoria ON producto.id_categoria=categoria.id_categoria;");
            return Conexion.ExecuteSentences(Sentencia);
        }
    }
}
