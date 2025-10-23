using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearPlanet
{
    public partial class AddPartnerForm : Form
    {
        public AddPartnerForm()
        {
            InitializeComponent();
        }

        // добавление нового партнера
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Введите название предприятия");
                return;
            }
            using (var connection = DatabaseHelper.ConnectToDatabase())
            {
                connection.Open();

                string query = @"INSERT INTO Partners (Type, Name, Director, Email, Phone, Address, Rating) 
                 VALUES (@Type, @Name, @Director, @Email, @Phone, @Address, @Rating)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", cbType.Text);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Director", txtFIO.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Phone", txtNumber.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@Rating", nudRating.Value);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Партнёр успешно добавлен");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
