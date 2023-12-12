using CarpinteriaApp.datos;
using RecetasSLN.datos.DAOs;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicio.Implementacion
{
    internal class ServicioDAO : IServicio
    {
        private IPedidoDAO pedidoDAO;
        private IClienteDAO clienteDAO;
        public ServicioDAO()
        {
            pedidoDAO = new PedidoDAO();
            clienteDAO = new ClienteDAO();
        }

        public int ActualizarEntrega(string sp, List<Parametro> lParam)
        {
            return pedidoDAO.ActualizarEntrega(sp, lParam);
        }

        public int RegistrarBaja(string sp, List<Parametro> lParam)
        {
            return pedidoDAO.RegistrarBaja(sp, lParam);
        }

        public List<ClienteDTO> TraerClientes(string sp, List<Parametro> lParam)
        {
            return clienteDAO.TraerClientes(sp, lParam);
        }

        public List<PedidoDTO> TraerPedidos(string sp, List<Parametro> lParam)
        {
            return pedidoDAO.TraerPedidos(sp, lParam);
        }
    }
}
