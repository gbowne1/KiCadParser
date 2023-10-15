using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
{
    Console.WriteLine("Please enter the filename of the .pro file:");
    string filename = Console.ReadLine();

    Dictionary<string, string> values = new Dictionary<string, string>();

    using (StreamReader sr = new StreamReader(filename))
    {
        string line;
        string section = "";

        while ((line = sr.ReadLine()) != null)
        {
            line = line.Trim();

            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                section = line.Substring(1, line.Length - 2);
            }
            else if (line.Contains("="))
            {
                string[] parts = line.Split('=');
                string key = parts[0].Trim();
                string value = parts[1].Trim();

                values.Add(section + "." + key, value);
            }
            else if (line.StartsWith("LibDir="))
            {
                Console.WriteLine("Please enter the library file location in KiCAD:");
                string libDir = Console.ReadLine();

                Console.WriteLine("Are you using Windows or Linux/Unix/POSIX?");
                string os = Console.ReadLine();

                if (os.ToLower() == "windows")
                {
                    libDir = libDir.Replace("/", "\\");
                }
                else
                {
                    libDir = libDir.Replace("\\", "/");
                }

                values.Add("LibDir", libDir);
            }
        }
    }

    Console.WriteLine("Values in file " + filename + ":");
    foreach (KeyValuePair<string, string> kvp in values)
    {
        Console.WriteLine(kvp.Key + " = " + kvp.Value);
    }
}
}
