using System;
using System.Windows;
using Clase2_Registro.Entidades;

namespace Clase2_Registro.UI.Registros
{
    public partial class rActores : Window
    {
        Actores actor;
        public rActores()
        {
            InitializeComponent();
            actor = new Actores();
            this.DataContext = actor;
        }

        private void Limpiar()
        {
            this.actor = new Actores();
            this.DataContext = actor;
        }

        private bool Validar()
        {
            bool valido = true;

            if(NombresTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Error, persona no valida.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return valido;
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if(!Validar())
                return;
                
            var guardo = ActoresBLL.Guardar(actor);

            if(guardo)
            {
                Limpiar();
                MessageBox.Show("Se guardó exitosamente.", "¡Exito!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la persona.", "¡Fallo!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var actor = ActoresBLL.Buscar(Convert.ToInt32(ActorIdTextBox.Text));
            if(actor != null)
            {
                this.actor = actor;
            }
            else
            {
                this.actor = new Actores();
            }
            this.DataContext = this.actor;
        }

        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActoresBLL.Eliminar(Convert.ToInt32(ActorIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se eliminó exitosamente.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el actor.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        } 
    }
}