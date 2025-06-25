using System;
using System.IO;
using System.Collections.Generic;
using Course.Entities;
using System.Globalization;

namespace Course;


class Program
{
    static void Main(string[] args)
    {

        /*   try
           {
               sr = File.OpenText(path);
               while (!sr.EndOfStream)
               {

               string line = sr.ReadLine();
               Console.WriteLine(line);
               }
           }catch(IOException e)
           {
               Console.WriteLine("An error acurred");
               Console.WriteLine("Burro pra krl");
               Console.WriteLine(e.Message);
           }
           finally
           {
               if (sr != null) sr.Close();
           }
        */

        /*try
        {


            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        catch (IOException e)
        {
            Console.WriteLine("Burro");
            Console.WriteLine(e.Message);
        }
           */


        /*   string sourcePath = @"f:\file1.txt";
           string targetPath = @"f:\file2.txt";


           try
           {
               string[] lines = File.ReadAllLines(sourcePath);
               using (StreamWriter sw = File.AppendText(targetPath))
               {
                   foreach(string line in lines)
                   {
                       sw.WriteLine(line.ToUpper());
                   }
               }




           }
           catch (IOException e)
           {
               Console.WriteLine("Burro");
               Console.WriteLine(e.Message);
           }
        */


        /*
           string path = @"f:\myfolder";
           try
           {

              IEnumerable<string> folder =  Directory.EnumerateDirectories(path, "*.*",SearchOption.AllDirectories);
               Console.WriteLine("Folders: ");
               foreach(string s in folder)
               {
                   Console.WriteLine(s);
               }

               var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
               Console.WriteLine("Files: ");
               foreach (string s in files)
               {
                   Console.WriteLine(s);
               }

               Directory.CreateDirectory(path + "\\newfolder");

           }
           catch(IOException e)
           {
               Console.WriteLine("An error ocurred");
               Console.WriteLine(e.Message);
           }
        */



        /* string path = @"f:\myfolder/file1.txt";
         Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
         Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path));
         Console.WriteLine("PathSeparator: " + Path.PathSeparator);
         Console.WriteLine("GetFileName: " + Path.GetFileName(path));
         Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
         Console.WriteLine("GetExtension: " + Path.GetExtension(path));
         Console.WriteLine("GetFullPath: " + Path.GetFullPath(path));
         Console.WriteLine("GetTempPath: " + Path.GetTempPath());
        */

        Console.Write("Enter file full path: ");
        string sourceFilePath = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(sourceFilePath);

            string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
            string targetFolderPath = sourceFolderPath + @"\out";
            string targetFilePath = targetFolderPath + @"\summary.csv";

            Directory.CreateDirectory(targetFolderPath);

            using (StreamWriter sw = File.AppendText(targetFilePath))
            {
                foreach (string line in lines)
                {

                    string[] fields = line.Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    int quantity = int.Parse(fields[2]);

                    Product prod = new Product(name, price, quantity);

                    sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }







    }
}
