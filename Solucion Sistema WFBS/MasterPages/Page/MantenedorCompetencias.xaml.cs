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
using Controlador;

namespace MasterPages.Page
{
    /// <summary>
    /// Lógica de interacción para MantenedorCompetencias.xaml
    /// </summary>
    public partial class MantenedorCompetencias : System.Windows.Controls.Page
    {

        public MantenedorCompetencias()
        {
            InitializeComponent();
        }

        private void dgCompetencias_Loaded(object sender, RoutedEventArgs e)
        {
            Collections col = new Collections();
            dgCompetencias.ItemsSource = col.ReadAllCompetencias();
            /*dgCompetencias.Columns[6].Visibility = Visibility.Collapsed;*/

        }

        private void btnAgregarCompetencia_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            InsertarCompetencia nextPage = new InsertarCompetencia();
            navService.Navigate(nextPage);
        }

        private void btnModificarCompetencia_Click(object sender, RoutedEventArgs e)
        {
            if (dgCompetencias.SelectedItem != null)
            {
                Competencia us = (Competencia)dgCompetencias.SelectedItem;
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarCompetencia nextPage = new ModificarCompetencia(us.Id_competencia);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario antes", "Aviso:");
            }
        }
        private void btnEliminarCompetencia_Click(object sender, RoutedEventArgs e)
        {
            if (dgCompetencias.SelectedItem != null)
            {
                Competencia us = (Competencia)dgCompetencias.SelectedItem;
                us.Delete();
                MessageBox.Show("La Competencia seleccionada ha sido desactivada", "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorCompetencias nextPage = new MantenedorCompetencias();
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Competencia antes", "Aviso:");
            }
        }
    }
}
