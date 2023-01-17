using Newtonsoft.Json;
namespace SerialisationApp;

public class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        //Trainee joseph = new Trainee() { FirstName = "Joseph", LastName = "McCann", SpartaNo = 7, };

        _serialiser = new BinarySerialiser();

        //serialiser.SerialiserToFile<Trainee>($"{_path}/BinaryJoe.bin", joseph);

        Trainee joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryJoe.bin");

        _serialiser = new XMLSerialiser();

       // _serialiser.SerialiserToFile<Trainee>($"{_path}/XMLJoe.xml", joseph);

        joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/XMLJoe.xml");

        Course eng134 = new Course()
        {
            Title = "Engineering 134",
            Subject = "C# SDET",
            StartDate = new DateTime(2022, 11, 28)
        };

        eng134.AddTrainee(joseph);
        eng134.AddTrainee(new Trainee() { FirstName = "Ikra", LastName = "Dahir", SpartaNo = 10 });
        eng134.AddTrainee(new Trainee() { FirstName = "Mehdi", LastName = "Hamdi", SpartaNo = 5 });

        // _serialiser.SerialiserToFile<Course>($"{_path}/XMLCourse.xml", eng134);

        _serialiser = new JSONSerialiser();

        _serialiser.SerialiserToFile<Course>($"{_path}/JSONCourse.json", eng134);
    }   
}

[Serializable]
public class Trainee
{
    public string? FirstName { get; init; } //Question mark allows non null values (nullable value types further reading)
    public string? LastName { get; init; }
    public int? SpartaNo { get; init; }

    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";
    public override string ToString()
    {
        return $"{SpartaNo} - {FullName}";
    }
}

[Serializable]
public class Course
{
    public string Subject { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public List<Trainee> Trainees { get; } = new List<Trainee>();
    [field: NonSerialized]
    private readonly DateTime _lastRead;
    public Course()
    {
        _lastRead = DateTime.Now;
    }
    public void AddTrainee(Trainee newTrainee)
    {
        Trainees.Add(newTrainee);
    }
}