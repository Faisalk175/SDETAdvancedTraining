namespace SerialisationApp;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerialiser : ISerialise
{
    public void SerialiserToFile<T>(string filePath, T item)
    {
        FileStream fileStream = File.Create(filePath);
        // creating a BinaryFormatter object to use to serialise the item to file
        BinaryFormatter writer = new BinaryFormatter();
        writer.Serialize(fileStream, item);

        fileStream.Close();
    }

    public T DeserialiseFromFile<T>(string filePath)
    {
        Stream fileStream = File.OpenRead(filePath);

        BinaryFormatter reader = new BinaryFormatter();

        var deserialiseItem = (T)reader.Deserialize(fileStream);

        fileStream.Close();

        return deserialiseItem;
    }
}
