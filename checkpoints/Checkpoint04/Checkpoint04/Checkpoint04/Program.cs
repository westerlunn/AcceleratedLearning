using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace Checkpoint04
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGnomes();
        }

        private static void PrintGnomes()
        {
            ConsoleTableBuilder
                .From(Database.GetGnomesFromDatabase())
                .WithFormat(ConsoleTableBuilderFormat.Minimal)
                .ExportAndWriteLine();
        }
    }

    class Database
    {
        private static string conString =
            "Server = (localdb)\\mssqllocaldb; Database = GnomeDb; Trusted_Connection = True;";
        public static DataTable GetGnomesFromDatabase()
        {
            var sql = @"SELECT [Namn], [Skägg], [Ond], [Temperament] FROM Gnome";
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                using (dataTable)
                {
                    dataTable.TableName = "gnomes";
                    dataTable.Columns.Add("Namn", typeof(string));
                    dataTable.Columns.Add("Skägg", typeof(string));
                    dataTable.Columns.Add("Ond", typeof(string));
                    dataTable.Columns.Add("Temperament", typeof(string));

                    while (reader.Read())
                    {
                        dataTable.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                            reader.GetInt32(3));
                    }
                }
            }
            return dataTable;
        }


    }
}
