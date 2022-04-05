using System;
using System.Linq;
using MongoDB.Driver;
using System.Globalization;
using System.Collections.Generic;
using CrewService.Domain.Entities;

namespace CrewService.Infrastructure.Persistence
{
    public class CrewContextSeed
    {
        public static void SeedData(IMongoCollection<Crew> crewCollection)
        {
            bool isCollectionExist = crewCollection.Find(x => true).Any();

            if (!isCollectionExist)
            {
                crewCollection.InsertMany(GetDummyCrews());
            }
        }

        private static IEnumerable<Crew> GetDummyCrews()
        {
            return new List<Crew>()
            {
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A10",
                    CreateTime = DateTime.ParseExact("2018.06.12", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY9387",
                    FirstName = "İlber",
                    LastName = "Tuncel",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A11",
                    CreateTime = DateTime.ParseExact("2015.09.19", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY6251",
                    FirstName = "Kumsal",
                    LastName = "Berk",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A12",
                    CreateTime = DateTime.ParseExact("2020.12.02", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY7502",
                    FirstName = "Laçin",
                    LastName = "Alagül",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A13",
                    CreateTime = DateTime.ParseExact("2005.10.01", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY1009",
                    FirstName = "Günsel",
                    LastName = "Öztanır",
                    IsActive = true,
                    IsSenior = true,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A14",
                    CreateTime = DateTime.ParseExact("2005.10.01", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY9807",
                    FirstName = "Özgenç",
                    LastName = "Edib",
                    IsActive = true,
                    IsSenior = true,
                    HasSchedule = true
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A15",
                    CreateTime = DateTime.ParseExact("2018.03.14", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY6328",
                    FirstName = "Adil",
                    LastName = "Neyzel",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A16",
                    CreateTime = DateTime.ParseExact("2018.05.10", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY9674",
                    FirstName = "Mutlu",
                    LastName = "Hafiz",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A17",
                    CreateTime = DateTime.ParseExact("2016.11.25", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY2560",
                    FirstName = "Binalp",
                    LastName = "Üner",
                    IsActive = true,
                    IsSenior = true,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A18",
                    CreateTime = DateTime.ParseExact("2017.07.01", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY5621",
                    FirstName = "Sultan",
                    LastName = "Ayşan",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A19",
                    CreateTime = DateTime.ParseExact("2019.08.29", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY8261",
                    FirstName = "Kevser",
                    LastName = "Elem",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                },
                new Crew()
                {
                    Id = "9353F60A8459EA5ABA8F1A20",
                    CreateTime = DateTime.ParseExact("2019.05.01", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EmployeeNumber = "THY7481",
                    FirstName = "Vacide",
                    LastName = "Elfin",
                    IsActive = true,
                    IsSenior = false,
                    HasSchedule = false
                }
            };
        }
    }
}