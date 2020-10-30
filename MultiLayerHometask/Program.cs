using HairCut.Controllers;
using HairCut.Models.PostModels;
using System;

namespace MultiLayerHometask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new HairCutAppointmentController();
            controller.MinTimeBeforeAppointment = 0;

            var model = new CreateHairCutAppointmentPostModel
            {
                Date = DateTime.Now,
                FullName = "James Cameron",
                Phone = "+38093445520",
                Barber = "Jason Statham",
                HairCutStyle = "Under Cut",                         
                
            };
           
            //controller.CreateHairCutRequest(model);

            var allAppointments = controller.GetAll();
        }
    }
}
