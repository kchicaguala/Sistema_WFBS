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
    /// Lógica de interacción para InsertarCompetencia.xaml
    /// </summary>
    public partial class InsertarCompetencia : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        public InsertarCompetencia()
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
            cmbNivel.Items.Add("1");
            cmbNivel.Items.Add("2");
            cmbNivel.Items.Add("3");
            cmbNivel.Items.Add("4");
            cmbNivel.Items.Add("5");
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
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            List<Competencia> competencias = col.ReadAllCompetencias();
            List<Nivel> niveles = col.ReadAllNiveles();
            try
            {
                Competencia com = new Competencia();
                com.Id_competencia = int.Parse(txtId_Competencia.Text);
                if (!com.Read())
                {
                    com.Id_competencia = int.Parse(txtId_Competencia.Text);
                    com.Nombre = txtNombre.Text;
                    com.Descripcion = txtDescripcion.Text;
                    com.Sigla = txtSigla.Text;
                    com.Nivel_Optimo = int.Parse(cmbNivel.SelectedItem.ToString());
                    if (cmbObsoleta.SelectedIndex == 0)
                    {
                        com.Obsoleta = 0;
                    }
                    else
                    {
                        com.Obsoleta = 1;
                    }
                    foreach (Nivel n in niveles)
                    {
                        if (n.nota_Encuesta == (int)cmbNivel.SelectedItem)
                        {
                            com.Nivel_Optimo = n.nota_Encuesta;
                        }
                    }
                    com.Create();
                    MessageBox.Show("Agregado correctamente", "Éxito!");
                 
                    NavigationService navService = NavigationService.GetNavigationService(this);
                    MantenedorCompetencias nextPage = new MantenedorCompetencias();
                    navService.Navigate(nextPage);
                }

                else
                {
                    txtNombre.Text = txtNombre.Text + " - La competencia ya existe";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
