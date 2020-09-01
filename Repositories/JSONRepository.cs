namespace Technical_Test.Repositories
{
    using static System.Console;
    using System;
    using System.IO;

    /// <summary>
    /// writes a JSON file
    /// </summary>
    public class JSONRepository 
    {
        public void WriteAllData(string fileName, string json) 
        {
            try
            {   
                File.WriteAllText(fileName, json);        
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");  
            }
        }
    }
}