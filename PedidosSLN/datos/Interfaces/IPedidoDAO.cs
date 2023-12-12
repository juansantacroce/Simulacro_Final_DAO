using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Interfaces
{
    internal interface IPedidoDAO
    {
        List<PedidoDTO> TraerPedidos(string sp, List<Parametro> lParam);
        int ActualizarEntrega(string sp, List<Parametro> lParam);
        int RegistrarBaja(string sp, List<Parametro> lParam);
    }
}
