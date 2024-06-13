using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factura;
namespace Logeo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuario_Click_1(object sender, EventArgs e)
        {

            Factura1 formularioFactura = new Factura1();

            // Suscribirse al evento FormClosed del formulario de factura
            formularioFactura.FormClosed += (senderForm, eForm) =>
            {
                // Verificar si el formulario de factura se cerró correctamente
                if (eForm.CloseReason == CloseReason.UserClosing)
                {
                    // Mostrar nuevamente el formulario de inicio de sesión
                    this.Show();
                }
            };

            // Ocultar el formulario de inicio de sesión
            this.Hide();

            // Mostrar el formulario de factura
            formularioFactura.Show();

        }
       
        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
