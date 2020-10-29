using HairCut.Controllers;
using HairCut.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerHometask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new HairCutAppointmentController();

            var model = new CreateHairCutAppointmentPostModel
            {
                Date = DateTime.UtcNow,
                FullName = "James Cameron",
                Phone = "+38093445520",
                Barber = "Jason Statham",
                HairCutStyle = "Under Cut"
                
            };

            List<CreateHairCutAppointmentPostModel> lst = new List<CreateHairCutAppointmentPostModel>();

            lst.Add(model);
            controller.CreateHairCutRequest(model);
        }
    }
}
