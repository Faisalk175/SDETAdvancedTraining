

namespace SerialisationApp;

public interface ISerialise
{
    public void SerialiserToFile<T>(string filePath, T item);
    public T DeserialiseFromFile<T>(string filePath);
}
