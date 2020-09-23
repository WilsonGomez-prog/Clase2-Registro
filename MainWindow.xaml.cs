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
using Clase2_Registro.DAL;
using Clase2_Registro.Entidades;
using Clase2_Registro.UI.Registros;

namespace Clase2_Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            // InitializeComponent();
        }  

        public void rActoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rActores actor = new rActores();
            actor.Show();
        }    
    }
}
