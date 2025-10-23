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
    public partial class PartnerForm : Form
    {
        public PartnerForm()
        {
            InitializeComponent();

            LoadData();
        }

        // загрузка данных из бд в таблицу
        private void LoadData()
        {
            using (var connection = DatabaseHelper.ConnectToDatabase())
            {
                connection.Open();

                string query = @"select Type, Name, Director, Email, Phone, Address, INN, Rating 
                    from Partners";
                
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var partners = new List<Partner>();

                    while (reader.Read())
                    {
                        partners.Add(new Partner {
                            Type = reader.GetString(0),
                            Name = reader.GetString(1),
                            Director = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.GetString(4),
                            Address = reader.GetString(5),
                            INN = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            Rating = reader.GetInt32(7),
                        });
                    }

                    dataGridView1.DataSource = partners;
                }
            }
        }

        // открытие окна добавления нового партнера
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPartnerForm addPartnerForm = new AddPartnerForm();
            addPartnerForm.ShowDialog();
            LoadData();
        }
    }

    class Partner
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public int Rating { get; set; }
    }
}
