using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace KoTSaver
{
    class CollectionDatabases
    {
        private const string FileName = "Databases.xml";
        public List<Database> Databases { get; private set; }

        public CollectionDatabases()
        {

            Databases = new List<Database>();
            LoadFromXml();
        }

        private void LoadFromXml()
        {
            XDocument xdoc = XDocument.Load(FileName);
            foreach (
                XElement database in xdoc.Element(XmlElementsNames.HeadElement).Elements(XmlElementsNames.SubElement))
            {
                XAttribute id = database.Attribute(XmlElementsNames.Id);
                XElement baseId = database.Element(XmlElementsNames.BaseId);
                XElement layout = database.Element(XmlElementsNames.Layout);
                XElement timers = database.Element(XmlElementsNames.Timers);
                Databases.Add(new Database(int.Parse(id.Value), baseId.Value, layout.Value, timers.Value));
            }
        }

        public void AddItem(Database database)
        {
            Databases.Add(database);
            AddItemInXml(database);
        }

        public void EditItem(Database database)
        {
            int num = Databases.FindIndex(d => d.BaseId == database.BaseId&&d.Layout==database.Layout);
            Databases[num].Timers = database.Timers;
            EditItemInXml(Databases[num]);
        }

        public void DeleteItem(Database database)
        {
            int num = Databases.FindIndex(d => d.BaseId == database.BaseId && d.Layout == database.Layout);
            Databases.RemoveAt(num);
            DeleteItemInXml(database);
        }
        /// <summary>
        /// Добавляет новый объект в xml файл.
        /// </summary>
        /// <param name="database">Объект, который нужно добавить.</param>
        private void AddItemInXml(Database database)
        {
            XDocument xdoc = XDocument.Load(FileName);
            XElement root = xdoc.Element(XmlElementsNames.HeadElement);
            root.Add(new XElement(XmlElementsNames.SubElement,
                new XAttribute(XmlElementsNames.Id, database.Id),
                new XElement(XmlElementsNames.BaseId, database.BaseId),
                new XElement(XmlElementsNames.Layout, database.Layout),
                new XElement(XmlElementsNames.Timers, database.Timers)));

            xdoc.Save(FileName);
        }
        /// <summary>
        /// Изменяет объект в xml файле. 
        /// </summary>
        /// <param name="database">Объект, который нужно изменить.</param>
        private void EditItemInXml(Database database)
        {
            XDocument xdoc = XDocument.Load(FileName);
            XElement root = xdoc.Element(XmlElementsNames.HeadElement);
            foreach (XElement xe in root.Elements(XmlElementsNames.SubElement).ToList())
            {
                if (xe.Attribute(XmlElementsNames.Id).Value == database.Id.ToString())
                {
                    xe.Element(XmlElementsNames.Timers).Value = database.Timers;
                    break;
                }
            }
            xdoc.Save(FileName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        private void DeleteItemInXml(Database database)
        {
            XDocument xdoc = XDocument.Load(FileName);
            XElement root = xdoc.Element(XmlElementsNames.HeadElement);
            foreach (XElement xe in root.Elements(XmlElementsNames.SubElement).ToList())
            {
                if (xe.Attribute(XmlElementsNames.Id).Value == database.Id.ToString())
                {
                    xe.Remove();
                    break;
                }
            }
            xdoc.Save(FileName);
        }
        /// <summary>
        /// Ищет расстановку по номеру базы и имени расстановки.
        /// </summary>
        /// <param name="baseId">Номер базы.</param>
        /// <param name="layout">Имя расстановки.</param>
        /// <returns></returns>
        public Database GetDatabase(string baseId, string layout)
        {
            return Databases.Find(database => database.BaseId == baseId && database.Layout == layout);
        }
        /// <summary>
        /// Генерирует Id для нового объект.
        /// </summary>
        public int GenerateNewId()
        {
            return Databases.Count != 0 ? Databases.OrderBy(d => d.Id).Last().Id + 1 : 0;
        }
    }
}
