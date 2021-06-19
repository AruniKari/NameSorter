using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("name-sorter :");
                var fileName = Console.ReadLine();

                // Check the give file is exist
                if (File.Exists(fileName))
                {
                    FileStream fileStream = new FileStream(fileName, System.IO.FileMode.Open);

                    Dictionary<String, String> names = new Dictionary<String, String>();
                    List<FullName> NameList = new List<FullName>();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            var nameParts = line.Split(' ');
                            var lastName = nameParts.LastOrDefault();

                            var firstName = string.Join(" ", nameParts.Take(nameParts.Length - 1));
                           
                                FullName fullNameObj = new FullName();
                                fullNameObj.firstName = firstName;
                                fullNameObj.lastName = lastName;
                                NameList.Add(fullNameObj);                            
                        }
                    }
                   
                    string SortedPath = @".\sorted-names-list.txt";

                    if (File.Exists(SortedPath))
                    {
                        File.Delete(SortedPath);
                    }

                    List<FullName> SortedList = NameList.OrderBy(o => o.lastName).ToList();
                    for (int i = 0; i < SortedList.Count(); i++)
                    {
                        Console.WriteLine(SortedList[i].firstName.ToString() + " " + SortedList[i].lastName.ToString());
                        using (StreamWriter sw = File.AppendText(SortedPath))
                        {
                            sw.WriteLine(SortedList[i].firstName.ToString() + " " + SortedList[i].lastName.ToString());

                        }
                    }
                }
                else
                {
                    Console.WriteLine( "File does not exist.");
                }                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public class FullName
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        
    }
    
}
