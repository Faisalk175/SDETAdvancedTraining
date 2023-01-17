
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerialisationApp
{
    internal class XMLSerialiser : ISerialise
    {
        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);

            XmlSerializer reader = new XmlSerializer(typeof(T));

            var deserialiseItem = (T)reader.Deserialize(fileStream);

            fileStream.Close();

            return deserialiseItem;
        }

        public void SerialiserToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            // creating a BinaryFormatter object to use to serialise the item to file
            XmlSerializer writer = new XmlSerializer(item.GetType());
            writer.Serialize(fileStream, item);

            fileStream.Close();
        }
    }
}
