using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Redox_Code_Test
{
    /// <summary>
    /// Manages scheduling, canceling, and retrieving events while preventing double-booking.
    /// Persists data to a JSON file.
    /// </summary>
    public class EventScheduler
    {
        private List<Event> events;
        private readonly string storageFilePath;

        public EventScheduler(string filePath = "events.json")
        {
            storageFilePath = filePath;
            events = new List<Event>();
            LoadEvents();
        }

        /// <summary>
        /// Adds an event unless the time slot is already taken.
        /// </summary>
        public bool ScheduleEvent(string name, string location, DateTime dateTime)
        {
            // Check for double-booking
            if (IsTimeSlotTaken(dateTime))
            {
                Console.WriteLine($"Cannot schedule '{name}', at {dateTime:yyyy-MM-dd HH:mm}, as time slot is already taken.");
                return false;
            }

            var newEvent = new Event(name, location, dateTime);
            events.Add(newEvent);
            SaveEvents();
            Console.WriteLine($"Successfully scheduled: {newEvent}");
            return true;
        }

        /// <summary>
        /// Cancels an event by name.
        /// </summary>
        public bool CancelEvent(string name)
        {
            var eventToCancel = events.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if (eventToCancel == null)
            {
                Console.WriteLine($"Event '{name}' not found.");
                return false;
            }

            events.Remove(eventToCancel);
            SaveEvents();
            Console.WriteLine($"Successfully cancelled: {eventToCancel}");
            return true;
        }

        /// <summary>
        /// Gets all upcoming events sorted by date.
        /// </summary>
        public List<Event> GetUpcomingEvents()
        {
            return events
                .Where(e => e.DateTime >= DateTime.Now)
                .OrderBy(e => e.DateTime)
                .ToList();
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        public List<Event> GetAllEvents()
        {
            return events.OrderBy(e => e.DateTime).ToList();
        }

        /// <summary>
        /// Checks if a time slot is already taken (double-booking prevention).
        /// </summary>
        private bool IsTimeSlotTaken(DateTime dateTime)
        {
            return events.Any(e => e.DateTime == dateTime);
        }

        /// <summary>
        /// Saves events to local storage (JSON file).
        /// </summary>
        private void SaveEvents()
        {
            try
            {
                var json = JsonSerializer.Serialize(events, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
                File.WriteAllText(storageFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving events: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads events from local storage (JSON file).
        /// </summary>
        private void LoadEvents()
        {
            try
            {
                if (File.Exists(storageFilePath))
                {
                    var json = File.ReadAllText(storageFilePath);
                    events = JsonSerializer.Deserialize<List<Event>>(json) ?? new List<Event>();
                    Console.WriteLine($"Loaded {events.Count} events from storage.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading events: {ex.Message}");
                events = new List<Event>();
            }
        }
    }
}
