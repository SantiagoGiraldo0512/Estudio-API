using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarCombo();
            CargarGrid();


        }
        public void CargarCombo()
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:60148");
                HttpResponseMessage respuesta = cliente.GetAsync("/Api/TipoPersona").Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonTipoPersona = respuesta.Content.ReadAsStringAsync().Result;
                    var entityTipoPersona = (new JavaScriptSerializer()).Deserialize<List<TipoPersona>>(jsonTipoPersona);
                    comboTipoPersona.ItemsSource = entityTipoPersona;
                    comboTipoPersona.DisplayMemberPath = "descripcionTipoPersona";
                    comboTipoPersona.SelectedValuePath = "idTipoPersona";
                    comboTipoPersona.SelectedIndex = 0;

                }
            }
        }

        
        public void CargarGrid()
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:60148");
                HttpResponseMessage respuesta = cliente.GetAsync("/Api/Persona").Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var person = respuesta.Content.ReadAsStringAsync().Result;
                    var jsonPersona = (new JavaScriptSerializer()).Deserialize<List<Persona>>(person);
                    dataGrid.ItemsSource = jsonPersona;
                    dataGrid.CanUserAddRows = false;
                }
            }
        }
       
        //Eliminar Persona
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lblCodigoPersona.Content == "")
            {
                lblMensaje.Content = "No existe una persona seleccionada para eliminar";
            }
            else
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("http://localhost:60148/");
                    var response = cliente.DeleteAsync("Api/Persona/" + lblCodigoPersona.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        lblMensaje.Content = "Eliminación Exitosa";
                        CargarGrid();
                        LimpiarCampos();
                    }
                    else
                    {
                        lblMensaje.Content = "Error al intentar eliminar la persona";
                    }
                }
            }

        }

        //Pasar los datos
        private void DobleClicGrid()
        {
            string cont = dataGrid.SelectedValue.ToString();
            var row = (Persona)dataGrid.SelectedItem;
            if (row != null)
            {
                txtApellido.Text = (row.apellido == null) ? "" : row.apellido;
                txtNombre.Text = (row.nombre == null) ? "" : row.nombre;
                txtTelefono.Text = (row.telefono == null) ? "" : row.telefono;
                comboTipoPersona.SelectedValue = (row.idTipoPersona == null) ? "" : row.idTipoPersona.ToString();
                lblCodigoPersona.Content = (row.idPersona == null) ? "" : row.idPersona.ToString();
            }
        }

        //Guardar Persona
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Persona person = new Persona();
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtTelefono.Text != "" && comboTipoPersona.SelectedValue != "")
            {
                person.nombre = txtNombre.Text;
                person.apellido = txtApellido.Text;
                person.telefono = txtTelefono.Text;
                person.idTipoPersona = Int32.Parse(comboTipoPersona.SelectedValue.ToString());
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("http://localhost:60148/");
                    var response = cliente.PostAsJsonAsync("Api/Persona", person).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        lblMensaje.Content = "Registro Exitoso";
                        CargarGrid();
                        LimpiarCampos();
                    }
                    else
                    {
                        lblMensaje.Content = "Error al intentar almacenar la persona";
                    }
                }
            }
            else
            {
                lblMensaje.Content = "Complete todos los datos obligatorios";
            }
        }
        public void LimpiarCampos()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            lblCodigoPersona.Content = "";
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Persona)dataGrid.SelectedItem;
            if (row != null)
            {
                txtApellido.Text = row.apellido;
                txtNombre.Text = row.nombre;
                txtTelefono.Text = row.telefono;
                comboTipoPersona.SelectedValue = row.idTipoPersona.ToString();
                lblCodigoPersona.Content = row.idPersona.ToString();
            }

        }

        //Actualización
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txtApellido.Text == "" || txtNombre.Text =="" || txtTelefono.Text =="" || comboTipoPersona.SelectedValue ==null || lblCodigoPersona.Content == "")
            {
                lblMensaje.Content = "Favor diligencie los campos obligatorios para actualizar la persona";
            }
            else
            {
                Persona persona = new Persona();
                persona.nombre = txtNombre.Text;
                persona.apellido = txtApellido.Text;
                persona.idPersona = Int32.Parse(lblCodigoPersona.Content.ToString());
                persona.idTipoPersona = Int32.Parse(comboTipoPersona.SelectedValue.ToString());
                persona.telefono = txtTelefono.Text;
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("http://localhost:60148/");
                    var response = cliente.PutAsJsonAsync("Api/Persona/"+lblCodigoPersona.Content,persona).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        lblMensaje.Content = "Actualización Exitosa";
                        CargarGrid();
                        LimpiarCampos();
                    }
                    else
                    {
                        lblMensaje.Content = "Actualización Erronea";
                        LimpiarCampos();
                    }
                }
            }
        }



    }

    class Persona
    {
        public int idPersona { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String telefono { get; set; }
        public int idTipoPersona { get; set; }
    }
    class TipoPersona
    {
        public int idTipoPersona { get; set; }
        public String descripcionTipoPersona { get; set; }
    }
}
