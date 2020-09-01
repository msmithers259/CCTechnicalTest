namespace Technical_Test
{
    using static System.Console;
    using System;
    using System.IO;
    using Technical_Test.Services;
    using Technical_Test.Interfaces;
    using Technical_Test.Builders;
    // test command line parameters
    // dotnet run "c:\temp\address data.csv" "c:\temp\test.xml" "xml"
    // dotnet run "c:\temp\address data.csv" "c:\temp\test.json" "json"
    class Program
    {
        /// <summary>
        /// entry point for console application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // initialize variables
            var inputFile = string.Empty;   // file path and name to convert from
            var outputFile = string.Empty;  // file path and name to convert to
            var convertTo = string.Empty;   // type to convert to: xml and json are the only current options
            
            // if command line parameters use these and skip manual entry
            if (args.Length >= 3)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            inputFile = args[i];
                            break;
                        case 1:
                            outputFile = args[i];
                            break;
                        case 2:
                            convertTo = args[i];
                            break;
                        default:
                            // ignore any other parameters
                            break;
                    }
                }
            }
            else
            {
                // manually enter parameters
                EnterParameters(ref inputFile, ref outputFile, ref convertTo);
            }

            // read file and convert to a new format
            ConvertData(inputFile, outputFile, convertTo);
         
            WriteLine("Press any key to continue...");
            ReadKey();           
        }

        static void EnterParameters(ref string inputFile,  ref string outputFile, ref string convertTo)
        {
            // helper function to enter and return input
            string EnterParameter(string prompt, string defaultValue) 
            {
                // initialize variables
                var hasDefault = (!string.IsNullOrEmpty(defaultValue));
                var result = string.Empty;

                // user input
                WriteLine($"Please enter {prompt}");
                if (hasDefault)
                {
                    WriteLine($"Enter return for default value: {defaultValue}");
                }
                var input = ReadLine();

                // return input or default value (if relevant)
                result = (hasDefault && string.IsNullOrEmpty(input)) ? defaultValue : input;
                return result;
            }
    
            // enter parameters from terminal or command line    
            inputFile = EnterParameter(@"file to convert from (e.g C:\path\filename.csv)", inputFile);
            outputFile = EnterParameter(@"file to convert to (e.g C:\path\filename.xml)", outputFile);
            convertTo = EnterParameter(@"file type to convert (json or xml)", convertTo);
        }

        /// <summary>
        /// convert data from an input file to a new format and output to a new file
        /// this function could be broken down into smaller functions 
        /// i.e. getData, convertData, writeData functions
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="convertTo"></param>
        static void ConvertData(string inputFile, string outputFile, string convertTo)
        {
            // initialise variables
            CSVService inputService = null;
            IService<string, string, string> outputService = null;
            IBuilder builder = null;
            Converter converter = null;

            // get data
            inputService = new CSVService(inputFile);
            var lines = inputService.GetAllData();

            // create builder and output services dependent on new format required
            switch (convertTo.ToLower())
            {
                case "xml":
                    builder = new XMLBuilder("root", "entity");
                    outputService = new XMLService(outputFile);
                    break;
                case "json":
                    builder = new JSONBuilder();
                    outputService = new JSONService(outputFile);
                    break;
                default:
                     throw new ArgumentNullException("Invalid file format to convert to");
            }

            // do the conversion
            converter = new Converter(builder);
            var data = converter.ConvertCSV(lines.headings, lines.data);

            // write the new file
            outputService.WriteData(data);
            WriteLine($"Created {convertTo} file: {outputFile}");
        }
    }
}
