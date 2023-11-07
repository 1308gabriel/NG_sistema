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
    public partial class Form1_Autentication : Form
    {
        public Form1_Autentication()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=LAPTOP-J8IBN49U; database=sistema; integrated security=true");

        private void Form1_Autentication_Load(object sender, EventArgs e)
        {
            {
                
                conexion.Open();

                
                string query = "SELECT nombre_empresa FROM Empresa";

                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        
                        string nombreEmpresa = result.ToString();
                        label_nombreEmpresa.Text =  nombreEmpresa;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el nombre de la empresa en la base de datos.");
                    }
                }

                // Cierra la conexión a la base de datos.
                conexion.Close();
            }
        }

        bool contrasenaVisible = false;
        private void radioButton_ver_CheckedChanged(object sender, EventArgs e)
        {
            
            if (contrasenaVisible)
            {
                textBox_password.PasswordChar = '*';
            }
            else
            {
                textBox_password.PasswordChar = '\0';
            }

            contrasenaVisible = !contrasenaVisible;

        }

        int intentosFallidos = 0;

        private void button_ingresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBox_usuario.Text;
            string clave = textBox_password.Text;

            conexion.Open();

            // Consulta para verificar si el usuario existe.
            string existenciaQuery = "SELECT COUNT(*) FROM Usuario WHERE nombre = @nombre";
            using (SqlCommand existenciaCommand = new SqlCommand(existenciaQuery, conexion))
            {
                existenciaCommand.Parameters.AddWithValue("@nombre", nombreUsuario);

                int existencia = (int)existenciaCommand.ExecuteScalar();

                if (existencia == 0)
                {
                    MessageBox.Show("El nombre de usuario no existe. Ingresa un nombre de usuario válido.");
                }
                else
                {
                    // El usuario existe, ahora verificamos la contraseña.
                    string autenticacionQuery = "SELECT id_estado FROM Usuario WHERE nombre = @nombre AND clave = @clave";
                    using (SqlCommand command = new SqlCommand(autenticacionQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", nombreUsuario);
                        command.Parameters.AddWithValue("@clave", clave);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int estado = (int)result;

                            if (estado == 1)
                            {
                                if (intentosFallidos >= 3)
                                {
                                    MessageBox.Show("El usuario está bloqueado. Debe contactarse con el Administrador.");

                                    // Bloquear al usuario en la base de datos
                                    string bloqueoQuery = "UPDATE Usuario SET id_estado = 2 WHERE nombre = @nombre";
                                    using (SqlCommand bloqueoCommand = new SqlCommand(bloqueoQuery, conexion))
                                    {
                                        bloqueoCommand.Parameters.AddWithValue("@nombre", nombreUsuario);
                                        bloqueoCommand.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Inicio de sesión exitoso");
                                }
                                intentosFallidos = 0;
                            }
                            else if (estado == 2)
                            {
                                MessageBox.Show("El usuario está bloqueado. Debe contactarse con el Administrador.");
                            }
                            else
                            {
                                MessageBox.Show("Estado desconocido. Comuníquese con el administrador.");
                            }
                        }
                        else
                        {
                            intentosFallidos++;

                            if (intentosFallidos >= 3)
                            {
                                MessageBox.Show("Tercer intento fallido. El usuario ha sido bloqueado.");

                                // Bloquear al usuario en la base de datos
                                string bloqueoQuery = "UPDATE Usuario SET id_estado = 2 WHERE nombre = @nombre";
                                using (SqlCommand bloqueoCommand = new SqlCommand(bloqueoQuery, conexion))
                                {
                                    bloqueoCommand.Parameters.AddWithValue("@nombre", nombreUsuario);
                                    bloqueoCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Credenciales incorrectas. Intento " + intentosFallidos + " de 3.");
                            }
                        }
                    }
                }

                conexion.Close();
            }
        }

        private void label_nombreEmpresa_Click(object sender, EventArgs e)
        {

        }
    }
}


