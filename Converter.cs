namespace Technical_Test
{
    using static System.Console;
    using System;
    using System.Collections.Generic;
    using Technical_Test.Interfaces;

    /// <summary>
    /// converts a CSV file to other formats
    /// </summary>
    public class Converter
    {
        // the builder handles specific formats 
        private IBuilder builder;
        public Converter(IBuilder builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// convert CSV to other formats
        /// </summary>
        /// <param name="header"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ConvertCSV(string header, IReadOnlyCollection<string> data)
        {
            // get all the column names
            builder.BuildHeadings(header);
                        
            try
            {
                string previousParent;

                // process each line of data
                foreach (var line in data)
                {
                    var cols = line.Split(",");
                    previousParent = string.Empty;  
                    builder.StartEntity();// start new line processing      

                    for (var index = 0; index < cols.Length; index++)
                    {
                        // set up variables
                        (string name, string parent) = builder.GetHeading(index);
                        var value = cols[index];

                        // checking whether any processing is required when change of parent field
                        if (previousParent != parent)
                        {
                            if (previousParent != string.Empty)
                            {
                                builder.EndParentField();
                            };

                            if (parent != string.Empty)
                            {
                                builder.StartParentField(parent);
                            };
                        }

                        // add the actual field to the new format
                        builder.AddField(name, value);
                        previousParent = parent;
                    }

                    if (previousParent != string.Empty)
                    {
                        builder.EndParentField();
                    }

                    builder.EndEntity();// end processing for line
                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");  
            }

            // return the file contents as a string
            return builder.GetText();
        }        
    }
}