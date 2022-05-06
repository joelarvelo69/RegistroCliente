using ApplyGeek.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApplyGeek
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
            llenarDatos();

        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Registro reg = new Registro
                {
                    Nombre=txtNombre.Text,
                    Apellido=txtApellido.Text,
                    Edad=int.Parse(txtEdad.Text),
                    Direccion=txtDireccion.Text,
                    Email=txtEmail.Text,  
                };
                await App.SQLiteDB.SaveRegistroAsync(reg);
                
                await DisplayAlert("Registro", "Se guardo de manera exitosa el cliente", "Ok");
                LimpiarControles();
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }                     
        }

        /// <summary>
        /// Mostrar los datos
        /// </summary>
        public async void llenarDatos()
        {
            var clienteList = await App.SQLiteDB.GetRegistroAsync();
            if (clienteList != null)
            {
                lstCliente.ItemsSource = clienteList;
            }
        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                respuesta = false;
            }
            else
            { 
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                Registro registro = new Registro()
                {
                    IdCliente = Convert.ToInt32(txtIdCliente.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text                          
                };


                await App.SQLiteDB.SaveRegistroAsync(registro);
                await DisplayAlert("Registro", "Se actualizo de manera exitosa el cliente", "Ok");

                LimpiarControles();
                txtIdCliente.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnRegistrar.IsVisible = true;
                btnEliminar.IsVisible = false;
                llenarDatos();
            }

           
        }

        private async void lstCliente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Registro)e.SelectedItem;
            btnRegistrar.IsVisible = false;
            txtIdCliente.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdCliente.ToString()))
            {
                var registro = await App.SQLiteDB.GetRegistroByIdAsync(obj.IdCliente);
                if (registro!=null)
                {
                    txtIdCliente.Text = registro.IdCliente.ToString();
                    txtNombre.Text = registro.Nombre;
                    txtApellido.Text = registro.Apellido;
                    txtEdad.Text = registro.Edad.ToString();
                    txtDireccion.Text = registro.Direccion;
                    txtEmail.Text = registro.Email;             
                }       
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var registro = await App.SQLiteDB.GetRegistroByIdAsync(Convert.ToInt32(txtIdCliente.Text));
            if (registro!=null)
            {
                await App.SQLiteDB.DeleteRegistroAsync(registro);
                await DisplayAlert("Cliente", "Se elimino de manera exitosa", "Ok");
                LimpiarControles();
                llenarDatos();
                txtIdCliente.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnRegistrar.IsVisible = true;

            }
        }

        public void LimpiarControles ()
        {
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }

        private void direcciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
