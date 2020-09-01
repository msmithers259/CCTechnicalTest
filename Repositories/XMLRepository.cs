namespace Technical_Test.Repositories
{
    using static System.Console;
    using System;
    using System.Xml;

    /// <summary>
    ///  writes an XML file
    /// </summary>
    public class XMLRepository
    {
        public void WriteAllData(string fileName, string xml) 
        {
            XmlDocument document = null;
            XmlWriter writer = null;  
            XmlWriterSettings settings = null;

            try
            {   
                document = new XmlDocument();
                settings = new XmlWriterSettings();
                settings.Indent = true;
                document.LoadXml(xml);
                writer = XmlWriter.Create(fileName, settings);
                document.Save(writer);
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");  
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                }
            }
        }
    }
}