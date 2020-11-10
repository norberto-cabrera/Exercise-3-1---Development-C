using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Exercise_3_1___Development_C
{
    class Program
    {
        static void Main(string[] args)
        {
            var price="0";

            string Reader(string name)
            {
                string fileName = "breakfast.xml";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                
                XmlTextReader xmlReader = new XmlTextReader(path);
                List<string> names = new List<string>();
                List<string> values = new List<string>();

                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            names.Add(xmlReader.Name.ToString());
                            break;
                        case XmlNodeType.Text:
                            values.Add(xmlReader.Value);
                            break;
                    }
                }

                for (int i = 0; i < values.Count; i++)
                {
                    
                    if (values[i] == name)
                    {
                        Console.WriteLine("Name of the Product: " + values[i]);
                        price = values[i+1];
                        
                    }
                }
                return price;
            }

            Console.WriteLine("Price: " + Reader("French Toast"));
        }
    }
}
