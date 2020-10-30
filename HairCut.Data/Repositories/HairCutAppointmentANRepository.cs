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
    }
}
