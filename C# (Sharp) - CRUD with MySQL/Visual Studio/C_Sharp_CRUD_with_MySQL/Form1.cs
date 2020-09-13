using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C_Sharp_CRUD_with_MySQL
{
    public partial class Form1 : Form
    {
        MySqlConnection mySqlConnection;
        MySqlCommand mySqlCommand;
        MySqlDataReader mySqlDataReader;
        MySqlDataAdapter mySqlDataAdapter;
        string sql;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new MySqlConnection("Server=localhost;Database=crud;Uid=root");
               
                sql = "INSERT INTO User (name_user, fone_user) VALUES (@name_user, @fone_user)";

                mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@name_user", txtName.Text);
                mySqlCommand.Parameters.AddWithValue("@fone_user", mtbFone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ",""));

                mySqlConnection.Open();

                mySqlCommand.ExecuteNonQuery().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Data Successfully Inserted");
                mySqlConnection.Close();
                mySqlConnection = null;
                mySqlCommand = null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new MySqlConnection("Server=localhost;Database=crud;Uid=root");
                
                sql = "UPDATE User SET name_user = @name_user, fone_user = @fone_user WHERE id_user = @id";

                mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@id", txtID.Text);
                mySqlCommand.Parameters.AddWithValue("@name_user", txtName.Text);
                mySqlCommand.Parameters.AddWithValue("@fone_user", mtbFone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""));

                mySqlConnection.Open();

                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Data Successfully Edited");
                mySqlConnection.Close();
                mySqlConnection = null;
                mySqlCommand = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new MySqlConnection("Server=localhost;Database=crud;Uid=root");
                
                sql = "DELETE FROM user WHERE id_user = @id";

                mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@id", txtID.Text);

                mySqlConnection.Open();

                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Data Successfully Deleted");
                mySqlConnection.Close();
                mySqlConnection = null;
                mySqlCommand = null;
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new MySqlConnection("Server=localhost;Database=crud;Uid=root");

                sql = "SELECT * FROM user WHERE id_user = @id";

                mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@id", txtID.Text);

                mySqlConnection.Open();

                mySqlDataReader = mySqlCommand.ExecuteReader();

                while(mySqlDataReader.Read())
                {
                    txtName.Text = Convert.ToString(mySqlDataReader["name_user"]);
                    mtbFone.Text = Convert.ToString(mySqlDataReader["fone_user"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Data Consulted Successfully");
                mySqlConnection.Close();
                mySqlConnection = null;
                mySqlCommand = null;
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new MySqlConnection("Server=localhost;Database=crud;Uid=root");

                sql = "SELECT * FROM user";

                mySqlDataAdapter = new MySqlDataAdapter(sql, mySqlConnection);

                DataTable dataTable = new DataTable();

                mySqlDataAdapter.Fill(dataTable);

                dgvDataBase.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Data Displayed Successfully");
                mySqlConnection.Close();
                mySqlConnection = null;
                mySqlCommand = null;
            }
        }
    }
}
