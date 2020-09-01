namespace Technical_Test.Services
{
    using System.Collections.Generic;
    using Technical_Test.Interfaces;
    using Technical_Test.Repositories;

    /// <summary>
    /// returns data from the CSV repository
    /// </summary>
    public class CSVService : IService<string, string, string>
    {
        private string fileName;
        private CSVRepository repository;

        public CSVService(string fileName)
        {
            this.repository = new CSVRepository();
            this.fileName = fileName;                
        }

        public (string headings, IReadOnlyCollection<string> data) GetAllData()
        {
            var lines = repository.GetAllData(fileName);
            return (lines.headings, lines.data);
        }

        public void WriteData(string data)
        {
            throw new System.NotImplementedException();
        }

    }
}