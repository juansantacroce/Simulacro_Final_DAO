using CarpinteriaApp.datos;
using RecetasSLN.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.Servicio;
using RecetasSLN.Servicio.Implementacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultar : Form
    {
        private IServicio servicio;
        private List<PedidoDTO> lPedidos;
        public FrmConsultar()
        {
            InitializeComponent();
            servicio = new ServicioDAO();
            lPedidos = new List<PedidoDTO>();
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            CargarCombo();
            ContadorPedidos();
        }

        private void CargarCombo()
        {
            var lParam = new List<Parametro>();
            cboClientes.DataSource = servicio.TraerClientes("SP_CONSULTAR_CLIENTES", lParam);
            cboClientes.ValueMember = "Id";
            cboClientes.DisplayMember = "NombreCompleto";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            lPedidos.Clear();
            dgvPedidos.Rows.Clear();
            var lParam = new List<Parametro>();
            lParam.Add(new Parametro("@cliente", cboClientes.SelectedValue));
            lParam.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lParam.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            CargarListaPedidos( lParam );
            AgregarPedidoDGV();
            ContadorPedidos();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Queres salir pa?", "Cuchame", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidos.CurrentCell.ColumnIndex == 4)
            {

                if (dgvPedidos.CurrentRow.Cells[3].Value.ToString() == "N")
                {
                    var lParam = new List<Parametro>();
                    lParam.Add(new Parametro("@codigo", dgvPedidos.CurrentRow.Cells[0].Value));
                    var result = servicio.ActualizarEntrega("SP_REGISTRAR_ENTREGA", lParam);
                    if (result>0)
                    {
                        MessageBox.Show("Se actualizo bien pa!", "Cuchame", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Algo paso que no anduvo rey", "Cuchame", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("El pedido ya se entrego pa!", "Cuchame", MessageBoxButtons.OK);

                }
            }
            if (dgvPedidos.CurrentCell.ColumnIndex == 5)
            {
                var result = MessageBox.Show("Tas seguro pa?", "Cuchame", MessageBoxButtons.YesNo);
                var lParam = new List<Parametro>();
                lParam.Add(new Parametro("@codigo", Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value)));
                if (result == DialogResult.Yes)
                {
                    var deleteResult = servicio.RegistrarBaja("SP_REGISTRAR_BAJA", lParam);
                    if (deleteResult>0)
                    {
                        MessageBox.Show("Se borro pa!", "Cuchame", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Ya se habia borrado antes pa...", "Cuchame", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void CargarListaPedidos(List<Parametro> lParam)
        {
            var listaObtenida = servicio.TraerPedidos("SP_CONSULTAR_PEDIDOS", lParam);
            foreach (PedidoDTO p in listaObtenida)
            {
                lPedidos.Add(p);
            }
        }

        private void AgregarPedidoDGV()
        {
            foreach (PedidoDTO p in lPedidos)
            {
                dgvPedidos.Rows.Add(new object[] { p.Codigo, p.Cliente, p.FechaEntrega, p.Entregado});
            }
        }
        private void ContadorPedidos()
        {
            var cantidad = lPedidos.Count();
            lblTotal.Text = "Total de pedidos: " + cantidad.ToString();
        }

    }
}
