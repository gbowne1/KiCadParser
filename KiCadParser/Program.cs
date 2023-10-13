using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string filename = "Z80.pro";
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
            }
        }

        foreach (KeyValuePair<string, string> kvp in values)
        {
            Console.WriteLine(kvp.Key + " = " + kvp.Value);
        }
    }
}
