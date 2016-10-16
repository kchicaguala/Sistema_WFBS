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
    /// Lógica de interacción para EliminarCompetencia.xaml
    /// </summary>
    public partial class EliminarCompetencia : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        public EliminarCompetencia()
        {
            InitializeComponent();
        }
        private void cmbObsoleta_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> obsoleta = new List<string>();
            obsoleta.Add("Si");
            obsoleta.Add("No");
            var cmbObsoleta = sender as ComboBox;
            cmbObsoleta.ItemsSource = obsoleta;
            cmbObsoleta.SelectedIndex = 0;

        }

        private void cmbNivel_Loaded(object sender, RoutedEventArgs e)
        {
            List<Nivel> niveles = col.ReadAllNiveles();
            foreach (Nivel item in niveles)
            {
                cmbNivel.Items.Add(item.nota_Encuesta);
            }
            cmbNivel.SelectedIndex = 0;
        }
        private void cmbObsoleta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbObsoleta.SelectedIndex != 0)
            {
                lbNivel.Visibility = Visibility.Hidden;
                cmbNivel.IsEnabled = false;
                cmbNivel.Visibility = Visibility.Hidden;
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSigla.Text = string.Empty;
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            List<Competencia> competencias = col.ReadAllCompetencias();
            List<Nivel> niveles = col.ReadAllNiveles();
            try
            {
                Competencia com = new Competencia();
                com.Id_competencia = int.Parse(txtId_Competencia.Text);
                if (com.Read())
                {
                    com.Delete();
                    MessageBox.Show("Competencia eliminada correctamente", "Éxito!");
                }

                else
                {
                    txtNombre.Text = txtNombre.Text + " - La competencia no existe";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
