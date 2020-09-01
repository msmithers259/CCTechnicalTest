namespace Technical_Test.Interfaces
{
    using System.Collections.Generic;
    /// <summary>
    /// interface for services handling input and output of different file formats
    /// </summary>
    /// <typeparam name="T">column headings</typeparam>
    /// <typeparam name="U">readonly data held in collection</typeparam>
    /// <typeparam name="V">data to write to output file</typeparam>
    public interface IService<T, U, V> 
        where T : class
        where U : class
        where V : class
    {
        /// <summary>
        /// get data from file
        /// </summary>
        /// <returns>column headings and file data</returns>
         (T headings, IReadOnlyCollection<U> data) GetAllData();
         
         /// <summary>
         /// write data to a file 
         /// </summary>
         /// <param name="data">the data to write</param>
         void WriteData(V data);
    }
}