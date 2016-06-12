using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseOnFile;

namespace TestsDbTransport
{
    class Generator
    {
        public static Car GenerateRandomCar()
        {
            var rand = new Random();
            return new Car(rand.Next(1, 100), rand.Next(1, 100), new DateTime(rand.Next()),
                GenerateRandomEquipment(rand.Next(40)))
            {
                Mark = GenerateRandomString(rand.Next(20)),
                Color = (Color)rand.Next(1, 6),
                StateLicensePlate = GenerateRandomString(rand.Next(10))
            };
        }

        public static Camel GenerateRandomCamel()
        {
            var rand = new Random();
            return new Camel(rand.Next(1, 100), rand.Next(1, 100), new DateTime(rand.Next()),
                GenerateRandomEquipment(rand.Next(40)))
            {
                NumberHumped = (Camel.Humped)rand.Next(1, 3),
                Sex = (Camel.Gender)rand.Next(1, 3),
                Weight = rand.Next(100, 500)
            };
        }

        private static List<string> GenerateRandomEquipment(int length)
        {
            Random rand = new Random();
            var equipment = new List<string>();

            for (int i = 0; i < length; i++)
            {
                equipment.Add(GenerateRandomString(rand.Next(100)));
            }

            return equipment;
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
