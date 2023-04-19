using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Polygon
{
    // класс для хранения полигона
    public class Polygon
    {
        public string Type { get; set; }
        public List<List<List<double>>> Coordinates { get; set; }
        public Dictionary<string, object> Properties { get; set; }

        public Polygon()
        {
            Type = "Feature";
            Coordinates = new List<List<List<double>>>();
            Properties = new Dictionary<string, object>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // создаем экземпляр полигона
            Polygon polygon = new Polygon();
            polygon.Type = "Feature";

            // задаем координаты полигона
            List<List<double>> polygonCoordinates = new List<List<double>>();
            polygonCoordinates.Add(new List<double>() { 100.0, 0.0 });
            polygonCoordinates.Add(new List<double>() { 101.0, 0.0 });
            polygonCoordinates.Add(new List<double>() { 101.0, 1.0 });
            polygonCoordinates.Add(new List<double>() { 100.0, 1.0 });
            polygonCoordinates.Add(new List<double>() { 100.0, 0.0 });
            polygon.Coordinates.Add(polygonCoordinates);

            // задаем свойства полигона
            polygon.Properties.Add("prop0", "value0");
            polygon.Properties.Add("prop1", new Dictionary<string, object>() { { "this", "that" } });

            try
            {
                // сериализуем полигон в строку с помощью Newtonsoft.Json
                string polygonJson = JsonConvert.SerializeObject(polygon, Formatting.Indented);

                // сохраняем строку в файл D:\polygon.txt
                string path = "D:\\polygon.txt";
                File.WriteAllText(path, polygonJson);

                Console.WriteLine("Polygon saved to file 123321.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}

