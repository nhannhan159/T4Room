using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RoomM.WebService;

namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(RoomService)))
            {
                host.Open();
                Console.WriteLine("Service1 Started");

                using (ServiceHost host1 = new ServiceHost(typeof(StaffTypeService)))
                {
                    host1.Open();
                    Console.WriteLine("Service2 Started");
                    Console.ReadLine();
                }
            }
            
        }
    }
}
