using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClearPlanet
{
    public class DatabaseHelper
    {
        // подключение к бд
        public static SqlConnection ConnectToDatabase()
        {
            string path = "Data Source=MILKYWAY;Initial Catalog=DemoExam;Integrated Security=True";
            return new SqlConnection(path);
        }
    }
}
