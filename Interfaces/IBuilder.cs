namespace Technical_Test.Interfaces
{
    /// <summary>
    /// interface for builders used by the convertor
    /// </summary>
    public interface IBuilder
    {
        // pass in an index and return column heading details    
        public (string name, string parentName) GetHeading(int index);
        
        // convert a string of column names into the proper format
        public void BuildHeadings(string columnHeadings);             
        
        // do any processing required when converting a new record 
        public void StartEntity();

        // do any processing required when finished converting a new record 
        public void EndEntity();
        
        // do any processing required when converting a field
        public void AddField(string name, string value);
        
        // do any processing required when field\s have a parent field
        public void StartParentField(string name);
 
        // do any processing required when field has a new or no parent field
        public void EndParentField();

        // return the finished file contents as a string
        public string GetText();
    }
}