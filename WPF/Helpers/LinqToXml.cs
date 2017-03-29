using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;

namespace WPF.Helpers
{
    public class LinqToXml : List<Entitypokus>
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

        private List<Entitypokus> GetChild(XElement xElement)
        {
            List<Entitypokus> lEntity = new List<Entitypokus>();

            foreach (XElement child in xElement.Elements())
            {
                Entitypokus entity = new Entitypokus(child.Attribute("Name").Value);

                entity.Items.AddRange(GetChild(child));

                lEntity.Add(entity);
            }

            return lEntity;
        }
    }
}
