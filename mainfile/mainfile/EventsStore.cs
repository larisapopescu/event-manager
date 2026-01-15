using System.Text.Json;

namespace mainfile;

public class EventsStore// aici incerc sa creez un fel de loc comun unde sa se poata vedea evenimentele, deoarece pana acum clientul nu avea acces la ele
{
    public static List<Event> LoadEvents(string filePath, JsonSerializerOptions options)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Event>>(json, options) ?? new List<Event>();
        }

        return new List<Event>();
    }

    public static void SaveEvents(List<Event> events, string filePath, JsonSerializerOptions options)
    {
        string json = JsonSerializer.Serialize(events, options);
        File.WriteAllText(filePath, json);
    }
}
