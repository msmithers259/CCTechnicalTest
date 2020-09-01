namespace Technical_Test.Builders
{
    using Newtonsoft.Json.Linq;
    using Technical_Test.Interfaces;

    /// <summary>
    /// builds the JSON file contents
    /// see IBuilder.cs and BaseBuilder.cs for more documentation
    /// </summary>
    public class JSONBuilder: BaseBuilder, IBuilder
    {
        private JArray jArray;
        private JObject parent;
        private JObject entity;
        private string parentName;

        public JSONBuilder()
        {
            this.jArray = new JArray();
        }

        public void StartEntity()
        {
            this.entity = new JObject();
        }
        public void EndEntity()
        {
            this.jArray.Add(this.entity);
        }

        public void AddField(string name, string value)
        {
            var property = new JProperty(name, value);

            if (this.parent != null) 
            {
                this.parent.Add(property);
            }
            else
            {
                this.entity.Add(property);
            }
        }

        public void StartParentField(string name)
        {
            this.parent = new JObject();
            this.parentName = name;
        }

        public void EndParentField()
        {
            this.entity.Add(this.parentName, this.parent);
            this.parent = null;
        }

        public string GetText()
        {
            return this.jArray.ToString();
        }
        
    }
}


