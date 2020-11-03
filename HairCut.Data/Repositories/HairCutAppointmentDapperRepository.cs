using Dapper;
using HairCut.Data.Interfaces;
using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairCut.Data.Repositories
{
    public class HairCutAppointmentDapperRepository : IHairCutAppointmentRepository
    {
        private readonly string _connectionString;

        public HairCutAppointmentDapperRepository()
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<HairCutAppointment>("SELECT * FROM HairCutAppointments");
            }
        }

        public HairCutAppointment GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<HairCutAppointment>("SELECT apt.* FROM HairCutAppointments apt" + $" WHERE apt.Id = {id}");
            }
        }

        public IEnumerable<HairCutAppointment> GetRecentAppointmentDates()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<HairCutAppointment>("SELECT apt.Date, apt.Barber FROM HairCutAppointments apt" +
                    $" WHERE apt.Date between GETDATE() AND DateAdd(DD,7,GETDATE())");
            }

        }
    }
}
