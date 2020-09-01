namespace Technical_Test.Repositories
{
    using static System.Console;
    using System;
    using System.IO;
    using System.Collections.Generic;
   
    public class CSVRepository 
    {
        /// <summary>
        /// get all contents of a text file
        /// </summary>
        /// <param name="fileName">path and name of file</param>
        /// <returns>headings as a single string and data as a collection of strings</returns>
        public (string headings, IReadOnlyCollection<string> data) GetAllData(string fileName)
        {
            WriteLine(fileName);
            // initialize variables
            var lines = new List<string>();
            var headingLine = string.Empty;
            var firstRecord = true;
            StreamReader reader = null;

            // read and store each line of the file
            try
            {
                reader = new StreamReader(File.OpenRead(fileName));    
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    // first record contains the headings 
                    if (firstRecord)
                    {
                        headingLine = line;
                        firstRecord = false;
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");  
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }

            // return headings and data as a tuple
            return (headings: headingLine, data: lines.AsReadOnly());
        }
   }
}