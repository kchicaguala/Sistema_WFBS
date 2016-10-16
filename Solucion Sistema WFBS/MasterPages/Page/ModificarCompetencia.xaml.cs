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
    /// Lógica de interacción para ModificarCompetencia.xaml
    /// </summary>
    public partial class ModificarCompetencia : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Competencia com = new Competencia();
        public ModificarCompetencia()
        {
            InitializeComponent();
        }

        public ModificarCompetencia(int id)
        {
            InitializeComponent();

            com.Id_competencia = id;
            com.Read();

            txtId_Competencia.Text = com.Id_competencia.ToString();
            txtNombre.Text = com.Nombre;
            txtDescripcion.Text = com.Descripcion;
            txtSigla.Text = com.Sigla;
            cmbObsoleta.SelectedIndex = com.Obsoleta;
            cmbNivel.SelectedIndex = com.Nivel_Optimo;
        }

        private void cmbObsoleta_Loaded(object sender, RoutedEventArgs e)
        {
            cmbObsoleta.Items.Add("0");
            cmbObsoleta.Items.Add("1");
            cmbObsoleta.SelectedItem = com.Obsoleta;

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
            if (cmbObsoleta.SelectedIndex == 1)
            {
                lbNivel.Visibility = Visibility.Visible;
                cmbNivel.IsEnabled = true;
                cmbNivel.Visibility = Visibility.Visible;
            }
            else
            {
                lbNivel.Visibility = Visibility.Hidden;
                cmbNivel.IsEnabled = false;
                cmbNivel.Visibility = Visibility.Hidden;
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSigla.Text = string.Empty;
            cmbNivel.SelectedIndex = 0;
            cmbObsoleta.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            List<Competencia> competencias = col.ReadAllCompetencias();
            List<Nivel> niveles = col.ReadAllNiveles();
            try
            {
                Competencia com = new Competencia();
                com.Id_competencia = int.Parse(txtId_Competencia.Text);
                if (com.Read())
                {
                    if (txtNombre.Text.Length > 0 && int.Parse(txtId_Competencia.Text) > 0)
                    {

                        com.Nombre = txtNombre.Text;
                        com.Descripcion = txtDescripcion.Text;
                        com.Sigla = txtSigla.Text;
                        if (cmbObsoleta.SelectedIndex == 0)
                            com.Obsoleta = 0;
                        else
                            com.Obsoleta = 1;
                        foreach (Nivel n in niveles)
                        {
                            if (n.nota_Encuesta == (int)cmbNivel.SelectedItem)
                            {
                                com.Nivel_Optimo = n.nota_Encuesta;
                            }
                        }
                        com.Update();
                        MessageBox.Show("Actualizado correctamente", "Éxito!");
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        MantenedorCompetencias nextPage = new MantenedorCompetencias();
                        navService.Navigate(nextPage);
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos antes de continuar", "Aviso");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No se ha podido modificar la competencia, verifique que la información esté correcta", "Error");
            }
        }
    }
}

