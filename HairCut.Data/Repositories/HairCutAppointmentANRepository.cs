using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Repositories
{
    public class HairCutAppointmentANRepository
    {
        private readonly string _connectionString;

        public HairCutAppointmentANRepository()
        {
            _connectionString = "Data source=.;Initial Catalog = BarberShop; Integrated Security = true";
        }

        public HairCutAppointment Create(HairCutAppointment model)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO  HairCutAppointments(FullName,Phone,HairCutStyle,Barber,Date)" +
                    $"VALUES(\'{model.FullName}\',\'{model.Phone}\',\'{model.HairCutStyle}\',\'{model.Barber}\',\'{model.Date.ToString("s")}\')";

                var insertedId = Convert.ToInt32(command.ExecuteScalar());
                model.Id = insertedId;
                return model;
            }
        }

        public IEnumerable<HairCutAppointment> GetAll()
        {
            var result = new List<HairCutAppointment>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM HairCutAppointments";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var hairCutAppointment = new HairCutAppointment();

                    hairCutAppointment.Id = reader.GetInt32(0);
                    hairCutAppointment.FullName = reader.GetString(1);
                    hairCutAppointment.Phone = reader.GetString(2);
                    hairCutAppointment.HairCutStyle = reader.GetString(3);
                    hairCutAppointment.Barber = reader.GetString(4);
                    hairCutAppointment.Date = (DateTime)reader["Date"];

                    result.Add(hairCutAppointment);
                }
                reader.Close();
            }
            return result;
        }
    }
}
