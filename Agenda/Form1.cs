using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using NegocioCapa;


namespace Agenda
{
    public partial class Form1 : Form
    {

        private ContactoNegocio contactoNegocio;

       
        public Form1()
        {
            InitializeComponent();
            contactoNegocio = new ContactoNegocio();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string idText = txtId.Text.Replace("Id:", "").Trim();
            int id;
            if (int.TryParse(idText, out id))
            {
                Contacto contacto = new Contacto
                {
                    Id = id,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtCorreo.Text
                };

                contactoNegocio.Modificar(contacto);
                MessageBox.Show("Contacto modificado exitosamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID valido.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idText = txtId.Text.Replace("Id:", "").Trim();
            int id;
            if (int.TryParse(idText, out id)) 
            {
                List<Contacto> resultados = contactoNegocio.Buscar(id);

                if (resultados.Count > 0)
                {
                    dgvResultados.DataSource = resultados; 
                }
                else
                {
                    MessageBox.Show("No se encontraron contactos.");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa un ID valido.");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string idText = txtId.Text.Replace("Id:", "").Trim();
            int id;
            if (int.TryParse(idText, out id))
            {
                contactoNegocio.Eliminar(id);
                MessageBox.Show("Contacto eliminado exitosamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID valido.");
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string idTexto = txtId.Text.Trim();

            
            if (idTexto.StartsWith("Id:"))
            {
                idTexto = idTexto.Substring(3).Trim(); 
            }

            
            int id;
            if (!int.TryParse(idTexto, out id)) 
            {
                MessageBox.Show("Por favor, ingrese un ID valido.");
                return; 
            }

            Contacto nuevoContacto = new Contacto
            {
                Id = id, 
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtCorreo.Text
            };

            contactoNegocio.Insertar(nuevoContacto);
            MessageBox.Show("Contacto guardado exitosamente.");
            LimpiarCampos();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
