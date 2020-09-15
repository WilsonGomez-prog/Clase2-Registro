using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clase2_Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Actores actor;
        public MainWindow()
        {
            InitializeComponent();
            actor = new Actores();
            this.DataContext = actor;
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            Contexto context = new Contexto();

            this.actor.Nombres = NombresTextBox.Text;
            this.actor.Salario = Convert.ToDecimal(SalarioTextBox.Text);

            context.Actores.Add(this.actor);

            int cant = context.SaveChanges();

            if (cant > 0)
            {
                MessageBox.Show("Guardado");
            }
            
            NombresTextBox.Text = "";
            SalarioTextBox.Text = "";
            context.Dispose();
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
            var found = context.Actores.Find(Convert.ToInt32(ActorIdTextBox.Text));
            
            if (found != null)
            {
                Actores actor = found;
                NombresTextBox.Text = actor.Nombres;
                SalarioTextBox.Text = Convert.ToString(actor.Salario);
            }
        }
    }
}
