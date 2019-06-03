using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using I4GUI2019Sommer.Models;

namespace I4GUI2019Sommer.Data
{
    public class Repository
    {
        internal static void ReadFile(string fileName, out ObservableCollection<Location> VarroaCounts)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextReader reader = new StreamReader(fileName);
            // Deserialize all the agents.
            VarroaCounts = (ObservableCollection<Location>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveFile(string fileName, ObservableCollection<Location> varroaCounts)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, varroaCounts);
            writer.Close();
        }
    }
}
