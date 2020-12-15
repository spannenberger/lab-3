using System;
using System.Collections.Generic;
using Library;
using Library.JSON;
using Library.Airplanes;

namespace lab3_8cs
{
    class Program
    {
        static void Main(string[] args)
        {
            var comp = new Airline();
            List<Crewman> crewmen = new List<Crewman>{
                new Crewman("pilot","a s d"),
                new Crewman("second pilot","d s d"),
                new Crewman("pilot","a s d"),
                new Crewman("second pilot","a a d"),
                new Crewman("flight attendant","a аыв d"),
                new Crewman("flight attendant","a вапр d"),
                new Crewman("flight attendant","a ролп d"),
            };
            var props = new List<Airplane>
            {
                new CargoAirplane(15000,15,new List<Crewman>{crewmen[0],crewmen[1] }),
                new CargoAirplane(15000,45,new List<Crewman>{crewmen[2],crewmen[3] }),
                new CargoAirplane(15000,115,new List<Crewman>{crewmen[0],crewmen[3] }),
                new PassengerAirplane(100,39,new List<Crewman>{crewmen[0],crewmen[3],crewmen[4],crewmen[5] }),
                new PassengerAirplane(150,48,new List<Crewman>{crewmen[0],crewmen[3],crewmen[6] }),
            };

            comp.Add(props);
            var serializer = new AirlineSerializer();
            serializer.SaveData("ManComp.xml",comp);
            var comp2 = serializer.LoadData("ManComp.xml");

            Console.WriteLine(comp);
            Console.WriteLine();
            Console.WriteLine(comp2);
            Console.WriteLine();
            Console.WriteLine(comp2[0]);
            Console.WriteLine();
            Console.WriteLine(comp2[1]);
            Console.WriteLine();
            Console.WriteLine(comp2[2]);
            Console.WriteLine();
            Console.WriteLine(comp2[^1]);
            Console.WriteLine();
            Console.WriteLine(comp2[^2]);

        }
    }
}
