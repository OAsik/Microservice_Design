using Dapper;
using Npgsql;
using System;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PilotEntity = Pilot.Domain.Entities.Pilot;

namespace Pilot.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();

                try
                {
                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

                    connection.Open();

                    using var command = new NpgsqlCommand() { Connection = connection };

                    command.CommandText = "drop table if exists Pilot";
                    command.ExecuteNonQuery();

                    command.CommandText = "create table Pilot(Id serial primary key not null, EmployeeNumber varchar(7) not null, FirstName varchar(30) not null, LastName varchar(30) not null, IsCaptain boolean not null, HasSchedule boolean not null, IsActive boolean not null, CreateTime date not null, UpdateTime date)";
                    command.ExecuteNonQuery();

                    connection.Execute("insert into Pilot (EmployeeNumber, FirstName, LastName, IsCaptain, HasSchedule, IsActive, CreateTime) values (@EmployeeNumber, @FirstName, @LastName, @IsCaptain, @HasSchedule, @IsActive, @CreateTime)", GetDummyPilots());
                }
                catch (Exception ex)
                {
                    if (retryAvailability < 50)
                    {
                        retryAvailability++;

                        System.Threading.Thread.Sleep(2000);

                        MigrateDatabase<TContext>(host, retryAvailability);
                    }
                }
            }

            return host;
        }

        private static IEnumerable<PilotEntity> GetDummyPilots()
        {
            return new List<PilotEntity>()
            {
                new PilotEntity()
                {
                    EmployeeNumber = "THY0785",
                    FirstName = "Nevzat",
                    LastName = "Kumul",
                    IsCaptain = false,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2018.06.12", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0206",
                    FirstName = "Hakkı",
                    LastName = "Özkurt",
                    IsCaptain = true,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2010.09.14", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0981",
                    FirstName = "Fezi",
                    LastName = "Tezalp",
                    IsCaptain = true,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2011.10.05", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0150",
                    FirstName = "Şerife",
                    LastName = "Serpin",
                    IsCaptain = false,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2019.02.27", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0892",
                    FirstName = "Siyami",
                    LastName = "Vecdet",
                    IsCaptain = false,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2018.06.12", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0649",
                    FirstName = "İhsan",
                    LastName = "Karasu",
                    IsCaptain = true,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2009.10.20", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0642",
                    FirstName = "Mücahit",
                    LastName = "Zati",
                    IsCaptain = false,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2015.05.30", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0593",
                    FirstName = "Gökay",
                    LastName = "Tecimen",
                    IsCaptain = true,
                    HasSchedule = true,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2014.12.03", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0267",
                    FirstName = "Tayfur",
                    LastName = "Cevval",
                    IsCaptain = true,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2013.07.01", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0199",
                    FirstName = "Sude",
                    LastName = "Kınay",
                    IsCaptain = true,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2013.04.01", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
                new PilotEntity()
                {
                    EmployeeNumber = "THY0482",
                    FirstName = "Talha",
                    LastName = "Cumali",
                    IsCaptain = false,
                    HasSchedule = false,
                    IsActive = true,
                    CreateTime = DateTime.ParseExact("2017.08.22", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                },
            };
        }
    }
}