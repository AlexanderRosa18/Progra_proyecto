using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public partial class Factura1 : Form
    {
        public Factura1()
        {
            InitializeComponent();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nom;

            cod = cmbProducto.SelectedIndex;
            nom = cmbProducto.SelectedItem.ToString();

            switch (cod)
            {
                case 0: lblCodigo.Text = "0011"; break;
                case 1: lblCodigo.Text = "0022"; break;
                default: lblCodigo.Text = "0033"; break;
            }

            switch (nom)
            {
                case "Polo":
                    lblNombre.Text = "Polo";
                    lblPrecio.Text = "10";
                    break;
                case "Gorra":
                    lblNombre.Text = "Gorra";
                    lblPrecio.Text = "12";
                    break;
                default:
                    lblNombre.Text = "Bebida Coca Cola";
                    lblPrecio.Text = "14";
                    break;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvLista);

            file.Cells[0].Value = lblCodigo.Text;
            file.Cells[1].Value = lblNombre.Text;

            // Verifica si lblPrecio.Text es numérico antes de intentar convertirlo
            float precio;
            if (float.TryParse(lblPrecio.Text, out precio))
            {
                file.Cells[2].Value = precio;
            }
            else
            {
                MessageBox.Show("El precio no es válido.");
                return;
            }

            int cantidad;
            if (int.TryParse(txtCantidad.Text, out cantidad))
            {
                file.Cells[3].Value = cantidad;
            }
            else
            {
                MessageBox.Show("La cantidad no es válida.");
                return;
            }

            // Calcula el total y asigna el valor a la celda
            float total = precio * cantidad;
            file.Cells[4].Value = total;

            dgvLista.Rows.Add(file);

            lblCodigo.Text = lblNombre.Text = lblPrecio.Text = txtCantidad.Text = "";

            obtenerTotal();
        }
        public void obtenerTotal()
        {
            float costot = 0;

            // Itera sobre las filas del DataGridView
            foreach (DataGridViewRow row in dgvLista.Rows)
            {
                float total;
                if (float.TryParse(row.Cells[4].Value.ToString(), out total))
                {
                    costot += total;
                }
            }

            lblTotatlPagar.Text = costot.ToString();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {
                DialogResult rppta = MessageBox.Show("¿Desea eliminar producto?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);
                }
            }
            catch { }
            obtenerTotal();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try {
                lblDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblTotatlPagar.Text)).ToString();

                
            }
            catch { }

            if (txtEfectivo.Text == "")
            {
                lblDevolucion.Text = "";
            }

        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();

            Ticket1.TextoCentro("Empresa xxxxx ");
            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoIzquierda("");
            Ticket1.TextoCentro("Factura de Venta");
            Ticket1.TextoIzquierda("No Fac: 0120102");
            Ticket1.TextoIzquierda($"Fecha: {DateTime.Now.ToShortDateString()} Hora: {DateTime.Now.ToShortTimeString()}");
            Ticket1.TextoIzquierda("Le Atendio: xxxx");
            Ticket1.TextoIzquierda("");
            clsFactura.CreaTicket.LineasGuion();
            clsFactura.CreaTicket.EncabezadoVenta();
            clsFactura.CreaTicket.LineasGuion();

            foreach (DataGridViewRow r in dgvLista.Rows)
            {
                Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse(r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse(r.Cells[4].Value.ToString()));
            }

            clsFactura.CreaTicket.LineasGuion();
            Ticket1.TextoIzquierda(" ");
            Ticket1.AgregaTotales("Total", double.Parse(lblTotatlPagar.Text));
            Ticket1.TextoIzquierda(" ");
            Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(txtEfectivo.Text));
            Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(lblDevolucion.Text));
            Ticket1.TextoIzquierda(" ");
            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoCentro("*     Gracias por preferirnos    *");
            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoIzquierda(" ");

            double total = double.Parse(lblTotatlPagar.Text);
            double pago = double.Parse(txtEfectivo.Text);

            if (!Ticket1.ValidarPago(total, pago))
            {
                return;
            }

            string impresoraNombre = "Microsoft XPS Document Writer";
            Ticket1.ImprimirTiket(impresoraNombre, total, pago);

            MessageBox.Show("Gracias por preferirnos");

            this.Close();
        }


        private void lblDevolucion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
