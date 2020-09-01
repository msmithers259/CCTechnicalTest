namespace Technical_Test.Services
{
     using System.Collections.Generic;

    using Technical_Test.Interfaces;
    using Technical_Test.Repositories;

    /// <summary>
    /// passes data to the JSON repository
    /// </summary>
    public class JSONService : IService<string, string, string>
    {
        private string fileName;
        private JSONRepository repository;

        public JSONService(string fileName)
        {
            this.repository = new JSONRepository();
            this.fileName = fileName;                
        }

        public (string headings, IReadOnlyCollection<string> data) GetAllData()
        {
            throw new System.NotImplementedException();
        }

        public void WriteData(string data)
        {
           this.repository.WriteAllData(fileName, data);
        }
    }
}