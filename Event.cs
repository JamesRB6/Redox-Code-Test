using System;

/// <summary>
/// Represents an event with a name, location, and date/time.
/// </summary>
public class Event
{
    /// <summary>Name of the event.</summary>
    public string Name { get; set; }

    /// <summary>Location of the event.</summary>
    public string Location { get; set; }

    /// <summary>Date and time of the event.</summary>
    public DateTime DateTime { get; set; }

    public Event(string name, string location, DateTime dateTime)
    {

        // Validate inputs    
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Event name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Event location cannot be empty.", nameof(location));

        if (dateTime < DateTime.Now)
            throw new ArgumentException("Event date/time cannot be in the past.", nameof(dateTime));

        // Assign properties once validated
        Name = name;
        Location = location;
        DateTime = dateTime;
    }

    /// <summary>Returns a string that represents the current event.</summary>
    public override string ToString()
        => $"{Name} at {Location} on {DateTime:yyyy-MM-dd HH:mm}";
}
