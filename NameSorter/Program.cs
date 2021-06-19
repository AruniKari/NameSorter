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

                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter a file name");
                    
                }
                Program program = new Program();
                program.SortingNames();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SortingNames()
        {
            try
            {
                Name nameObj = new Name();

               // Console.Write("name-sorter :");
                var fileName = Console.ReadLine();

                // Check the give file is exist
                if (File.Exists(fileName))
                {
                    FileStream fileStream = new FileStream(fileName, System.IO.FileMode.Open);

                    Dictionary<String, String> names = new Dictionary<String, String>();

                    List<Name> NameList = new List<Name>();
                    List<Name> InvalidNameList = new List<Name>();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Check the read line has only characters
                            if (nameObj.ValidString(line))
                            {

                                // Check the read line has firstname and last name
                                if (nameObj.ValidateLastNameExist(line))
                                {
                                    var nameParts = line.Split(' ');
                                    var lastName = nameParts.LastOrDefault();

                                    var firstName = string.Join(" ", nameParts.Take(nameParts.Length - 1));

                                    Name fullNameObj = new Name();
                                    fullNameObj.firstName = firstName;
                                    fullNameObj.lastName = lastName;
                                    NameList.Add(fullNameObj);
                                }
                                else
                                {
                                    //Save the invalid entries
                                    Name fullNameObj = new Name();
                                    fullNameObj.firstName = "Invalid entry -";
                                    fullNameObj.lastName = line;
                                    InvalidNameList.Add(fullNameObj);
                                }
                            }
                            else
                            {
                                Name fullNameObj = new Name();
                                fullNameObj.firstName = "Invalid characters -";
                                fullNameObj.lastName = line;
                                InvalidNameList.Add(fullNameObj);

                            }
                        }
                    }


                    Console.WriteLine($"{Environment.NewLine}Sorted Names list.{Environment.NewLine}");
                    List<Name> SortedList = NameList.OrderBy(o => o.lastName).ToList();
                    PrintNameList(SortedList);
                    WriteNameList(SortedList);


                    //print the  invalid entries
                    if (InvalidNameList.Count() >= 1)
                        Console.WriteLine($"{Environment.NewLine}Skipped Names list. {Environment.NewLine}");
                    PrintNameList(InvalidNameList);

                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void PrintNameList(List<Name> NameList)
        {

            for (int i = 0; i < NameList.Count(); i++)
            {
                Console.WriteLine(NameList[i].firstName.ToString() + " " + NameList[i].lastName.ToString());
            }

        }

        public void WriteNameList(List<Name> NameList)
        {

            string SortedPath = @".\sorted-names-list.txt";

            if (File.Exists(SortedPath))
            {
                File.Delete(SortedPath);
            }

            for (int i = 0; i < NameList.Count(); i++)
            {
                using (StreamWriter sw = File.AppendText(SortedPath))
                {
                    //write the  valid entries
                    sw.WriteLine(NameList[i].firstName.ToString() + " " + NameList[i].lastName.ToString());

                }
            }

        }

    }

}
