using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NG_sistema
{
    public partial class menu_principal : Form
    {
        SqlConnection conexion = new SqlConnection("server=LAPTOP-J8IBN49U; database=sistema; integrated security=true");

        public menu_principal()
        {
            InitializeComponent();
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {
            CargarOpcionesDeMenu();
        }

        private void CargarOpcionesDeMenu()
        {
            try
            {
                conexion.Open();

                // Consulta para obtener las opciones de menú desde la tabla 'menu' en la base de datos
                string query = "SELECT id_menu, titulo FROM menu";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Crea dinámicamente el MenuStrip
                    MenuStrip menuStrip = new MenuStrip();
                    this.Controls.Add(menuStrip);

                    // Agrega dinámicamente las opciones de menú al MenuStrip
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(row["titulo"].ToString());
                        menuItem.Tag = row["id_menu"];
                        menuItem.Click += OpcionDeMenu_Click;

                        // Obtenemos las subopciones para la opción de menú actual
                        List<string> subopciones = ObtenerSubopciones(Convert.ToInt32(row["id_menu"]));

                        // Agrega dinámicamente las subopciones al menú
                        foreach (string subopcion in subopciones)
                        {
                            string[] smesmenu = subopcion.Split('/');
                            ToolStripMenuItem subopcionItem = new ToolStripMenuItem(smesmenu[0]);
                            subopcionItem.Tag = smesmenu[1] + "/" + smesmenu[2];
                            subopcionItem.Click += Subopcion_Click;
                            menuItem.DropDownItems.Add(subopcionItem);
                        }

                        
                        // Agrega la opción de menú al MenuStrip
                        menuStrip.Items.Add(menuItem);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar opciones de menú: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }


        private void OpcionDeMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            int idMenuPrincipal = Convert.ToInt32(menuItem.Tag);

        }

        private void Subopcion_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem subMenu = (ToolStripMenuItem)sender;

    Control ctrGUI;
    string[] parametros = subMenu.Tag.ToString().Split('/');

    string libreria = parametros[0];
    string componente = parametros[1];

    ctrGUI = SmartControl.LoadSmartControl(libreria, componente);
    ctrGUI.SuspendLayout();

    // ctrGUI.Size = new Size(tabContenedor.Size.Width, tabContenedor.Size.Height);
    ctrGUI.BackColor = Color.White;
    ctrGUI.ResumeLayout();

    Form f1 = new Form();
    f1 = ctrGUI as Form;
    f1.MdiParent = this; //this refers to MainForm (parent)
    f1.Show();

    //var hw = radDockPrincipal.DockControl(ctrGUI, PosicionVentana, TipoVentana);
    //hw.CloseAction = Telerik.WinControls.UI.Docking.DockWindowCloseAction.CloseAndDispose;
    this.ResumeLayout();
    this.Cursor = Cursors.Default;

        }

        private List<string> ObtenerSubopciones(int idMenuPrincipal)
        {
            List<string> subopciones = new List<string>();

            try
            {
                using (SqlConnection conexion = new SqlConnection("server=LAPTOP-J8IBN49U; database=sistema; integrated security=true"))
                {
                    conexion.Open();

                    // Consulta para obtener las subopciones desde la tabla 'MenuRelaciones'
                    string query = "SELECT subopcion, libreria, componentes FROM MenuRelaciones WHERE id_menu_principal = @idMenuPrincipal";
                    using (SqlCommand command = new SqlCommand(query, conexion))

                    {
                        command.Parameters.AddWithValue("@idMenuPrincipal", idMenuPrincipal);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agrega cada subopción a la lista
                                string valor = "";
                                valor = reader["subopcion"].ToString() + "/" + reader["libreria"].ToString() + "/" + reader["componentes"].ToString();
                                subopciones.Add(valor);
                            }
                        }
                    }
                }



                return subopciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener subopciones: " + ex.Message);
                return subopciones;
            }


        }
    }
}
