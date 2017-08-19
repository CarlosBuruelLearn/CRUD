using CRUD.Lib.Conexion;

namespace CRUD
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Conexion cConnection;
        public Form1()
        {
            InitializeComponent();
            //Iniciar conexion
            cConnection = Conexion.obtenerConexion();
            //Obtain user
            getUsers();
            new CRUD.Lib.Faturacion.Facturacion();
        }

        private void getUsers()
        {
            string query =
                "SELECT "+
                " idUsuarios, vchNombre "+
                " FROM catusuarios";
            System.Data.DataTable dtUsers = cConnection.getQuery(query);
            if (dtUsers != null)
                dgvUsers.DataSource = dtUsers;
            else
                System.Windows.Forms.MessageBox.Show("Sin conexión");
        }

        private void insertUser()
        {
            string insertQuery = "INSERT INTO catusuarios(vchNombre) VALUES(@vchNombre)";
            string message;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(insertQuery);
            command.Parameters.AddWithValue("@vchNombre", "Carlos Buruel");
            if( !cConnection.isChangeDataBase(command) )
            {
                message = "Error de insercion";
                
            }
            else
            {
                getUsers();
                message = "Inserción correcta";
            }
            System.Windows.Forms.MessageBox.Show(message);
        }

        private void tsbAddUser_Click(object sender, System.EventArgs e)
        {
            insertUser();
        }

        private void editUser()
        {
            string updateQuery = "UPDATE catusuarios SET vchNombre = @vchNombre WHERE idUsuarios = 1";
            string message;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(updateQuery);
            command.Parameters.AddWithValue("@vchNombre", "Carlos Buruel Ortiz");
            if (!cConnection.isChangeDataBase(command))
            {
                message = "Error de insercion";
            }
            else
            {
                getUsers();
                message = "Actualización correcta";
            }
            System.Windows.Forms.MessageBox.Show(message);
        }

        private void tsbEditUser_Click(object sender, System.EventArgs e)
        {
            editUser();
        }
    }
}
