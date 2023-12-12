using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.DAOs
{
    class PedidoDAO : IPedidoDAO
    {
        public int ActualizarEntrega(string sp, List<Parametro> lParam)
        {
            var result = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lParam);
            return result;
        }

        public int RegistrarBaja(string sp, List<Parametro> lParam)
        {
            var result = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lParam);
            return result;
        }

        public List<PedidoDTO> TraerPedidos(string sp, List<Parametro> lParam)
        {
            var dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lParam);
            var lPedidos = new List<PedidoDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                var pedido = new PedidoDTO();
                pedido.Codigo = Convert.ToInt32(dr["codigo"]);
                pedido.Cliente = dr["cliente"].ToString();
                pedido.FechaEntrega = Convert.ToDateTime(dr["fec_entrega"]);
                pedido.Entregado = dr["entregado"].ToString();
                lPedidos.Add(pedido);
            }
            return lPedidos;
        }
    }
}
