﻿using ConsoleApp.BusinessLayer;
using ConsoleApp.Domain;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryBL queryToCountries = new CountryBL();
            Country country = new Country();
            List<Country> listOfCountries = new List<Country>();

            Console.WriteLine("Consulta a la base de datos (paises)");
            listOfCountries = queryToCountries.GetCountries();

            if (listOfCountries == null && queryToCountries.ErrorMessage != string.Empty)
            {
                Console.WriteLine("Error: {0}", queryToCountries.ErrorMessage);
            }
            else
            {
                foreach (var item in listOfCountries)
                {
                    Console.WriteLine("País : {0}", item.NameEs);
                    Console.WriteLine("ISO2 : {0} - ISO3: {1}", item.ISO2, item.ISO3);
                }
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Agregue un nuevo país.");
            Console.Write("Nombre en español: ");
            country.NameEs = Console.ReadLine();

            Console.Write("Nombre en inglés: ");
            country.NameEn = Console.ReadLine();

            Console.Write("Cód ISO2: ");
            country.ISO2 = Console.ReadLine();

            Console.Write("Cód ISO3: ");
            country.ISO3 = Console.ReadLine();

            bool record = queryToCountries.InsertCountry(country);
            if(record)
                Console.WriteLine("Los datos del país {0} fueron registrados con éxito.", country.NameEs);
            else
                Console.WriteLine("Error en el registro de datos: {0}", queryToCountries.ErrorMessage);

            //Console.Write("Id: ");
            //// Realizar la consulta a BD
            //int idCountry = Convert.ToInt32(Console.ReadLine());
            //country = queryToCountries.GetCountry(idCountry);

            //if (country != null)
            //{
            //    //mostrar el resultado:
            //    Console.WriteLine("El país tiene los siguientes datos: ");
            //    Console.WriteLine("Nombre: {0} - {1}", country.NameEn, country.ISO3);
            //}
            //else
            //    Console.WriteLine("No hay datos");

            Console.ReadLine();

        }
    }
}
