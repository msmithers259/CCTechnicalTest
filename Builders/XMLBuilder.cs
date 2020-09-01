namespace Technical_Test.Builders
{
    using System.Xml;
    using Technical_Test.Interfaces;

    /// <summary>
    /// builds the XML file contents
    /// see IBuilder.cs and BaseBuilder.cs for more documentation
    /// </summary>
    public class XMLBuilder : BaseBuilder, IBuilder
    {
        private XmlDocument xmlDocument;
        private XmlElement root;
        private XmlElement entity;
        private XmlElement parent;
        private string entityName;

        public XMLBuilder(string rootName, string entityName)
        {
            this.xmlDocument = new XmlDocument();
            this.root = this.xmlDocument.CreateElement(rootName);
            this.entityName = entityName;
        }

        public void StartEntity()
        {
            this.entity = xmlDocument.CreateElement(entityName);
        }

        public void EndEntity()
        {
            root.AppendChild(this.entity);
        }

        public void AddField(string name, string value)
        {
            var element = xmlDocument.CreateElement(name);
            element.InnerText = value;

            if (parent != null) 
            {
                parent.AppendChild(element);
            }
            else
            {
                entity.AppendChild(element);
            }
        }

        public void StartParentField(string name)
        {
            parent = xmlDocument.CreateElement(name);
        }

        public void EndParentField()
        {
            entity.AppendChild(parent);
            parent = null;
        }

        public string GetText()
        {
            return root.OuterXml;
        }

    }
}
