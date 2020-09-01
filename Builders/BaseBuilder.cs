namespace Technical_Test.Builders
{
    /// <summary>
    /// this is the base class for all the builders
    /// it builds and stores column names for use by the parent class
    /// </summary>
    public abstract class BaseBuilder 
    {
        // holds the name of the column and the name of the parent column (if a parent column exists)
        private struct Heading
        {
            public string name;
            public string parentName;
        };  

        // array of column names
        private Heading[] headings;

        /// <summary>
        /// pass in an index and return column heading details
        /// </summary>
        /// <param name="index"></param>
        /// <returns>tuple containing column name and column parent name</returns>
        public (string name, string parentName) GetHeading(int index)
        {
            var heading = headings[index];    
            return (name: heading.name, parentName: heading.parentName);
        }

        /// <summary>
        /// convert a string of column names into the proper format and store in an array for easy access
        /// </summary>
        /// <param name="columnHeadings">column headings as a string delimited by commas</param>
        public void BuildHeadings(string columnHeadings)
        {
            // delimit the headings into a string array
            var columns = columnHeadings.Split(",");
            int length = columns.Length;
            headings = new Heading[length];

            // create an array entry for every column
            for (int index = 0; index < length; index++)
            {
                var column = columns[index];
                var separator = column.IndexOf("_");
                var parent = string.Empty;
                var child = string.Empty;

                // set up parent and child names by delimiting by the underscore
                if (separator > -1)
                {
                    parent = column.Substring(0, separator);
                    child = column.Substring(separator + 1); 
                }
                else
                // some columns might not have a parent so just set up child details
                {
                    child = column;
                }

                // add to the internal array
                headings[index].name = child;
                headings[index].parentName = parent; 
            }
        }
    }
}