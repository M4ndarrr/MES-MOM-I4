using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Windows;
using System.Reflection;
using System.Windows.Resources;
using System.Xml;

namespace WPF
{
    public class LinqToXml : List<Entity>
    {
        public LinqToXml()
        {
            string resource = "Data.xml";
            AssemblyName assemblyName = new AssemblyName(typeof(LinqToXml).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(resourceUri);
            XmlReader reader = XmlReader.Create(resourceInfo.Stream);
            XDocument doc = XDocument.Load(reader);

            AddRange(GetChild(doc.Element("Folders")));
        }

        private List<Entity> GetChild(XElement xElement)
        {
            List<Entity> lEntity = new List<Entity>();

            foreach (XElement child in xElement.Elements())
            {
                Entity entity = new Entity(child.Attribute("Name").Value);
                entity.Items.AddRange(GetChild(child));

                lEntity.Add(entity);
            }

            return lEntity;
        }
    }

    public class Entity
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        private List<Entity> items;
        public List<Entity> Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                this.items = value;
            }
        }

        public Entity(string name)
        {
            this.Name = name;
            this.Items = new List<Entity>();
        }
    }
}
