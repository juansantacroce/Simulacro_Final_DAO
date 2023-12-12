using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Interfaces
{
    internal interface IClienteDAO
    {
        List<ClienteDTO> TraerClientes(string sp, List<Parametro> lParam);
    }
}
