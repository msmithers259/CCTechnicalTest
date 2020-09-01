namespace Technical_Test.Services
{
    using System.Collections.Generic;
    using Technical_Test.Interfaces;
    using Technical_Test.Repositories;

    /// <summary>
    /// passes data to the XML repository
    /// </summary>
    public class XMLService : IService<string, string, string>
    {
        private string fileName;
        private XMLRepository repository;

        public XMLService(string fileName)
        {
            this.repository = new XMLRepository();
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