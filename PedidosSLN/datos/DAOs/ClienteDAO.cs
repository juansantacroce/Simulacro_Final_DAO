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
    internal class ClienteDAO : IClienteDAO
    {
        public List<ClienteDTO> TraerClientes(string sp, List<Parametro> lParam)
        {
            var dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lParam);
            var lClientes = new List<ClienteDTO>();
            foreach (DataRow r in dt.Rows)
            {
                var cliente = new ClienteDTO();
                cliente.Id = Convert.ToInt32(r[0]);
                cliente.NombreCompleto = r[1]+ " " + r[2];
                lClientes.Add(cliente);
            }
            return lClientes;
        }
    }
}
