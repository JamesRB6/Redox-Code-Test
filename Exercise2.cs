using System;

namespace Redox_Code_Test
{
    public static class Exercise2
    {
        /// <summary>
        /// Demonstrates the EventScheduler with scheduling, canceling, and retrieving events.
        /// </summary>
        public static void Run()

        {
            try
            {
                Console.WriteLine("\nCreating Redox Event Scheduler:");
                var scheduler = new EventScheduler();

                // Schedule some events
                Console.WriteLine("\nScheduling Events:");

                scheduler.ScheduleEvent(
                    "Annual Safety & Compliance Briefing",
                    "Redox Sydney HQ - Minto, NSW",
                    new DateTime(2025, 11, 15, 09, 00, 0));

                scheduler.ScheduleEvent(
                    "Client Visit: Animal Health & Nutrition Launch",
                    "Redox Sydney Sales Office",
                    new DateTime(2025, 11, 19, 11, 00, 0));

                scheduler.ScheduleEvent(
                    "Warehouse Audit - Bulk Chemical Storage",
                    "Redox Minto Warehouse",
                    new DateTime(2025, 11, 16, 14, 00, 0));

                // Test double booking prevention
                Console.WriteLine("\nTesting Double Booking Prevention:");
                scheduler.ScheduleEvent(
                    "Storage Safety Inspection",
                    "Redox Minto Warehouse",
                    new DateTime(2025, 11, 15, 09, 00, 0));


                // Display upcoming events
                Console.WriteLine("\nUpcoming Events:");
                var upcomingEvents = scheduler.GetUpcomingEvents();
                if (upcomingEvents.Count == 0)
                {
                    Console.WriteLine("No upcoming events.");
                }
                else
                {
                    foreach (var evt in upcomingEvents)
                    {
                        Console.WriteLine($" - {evt}");
                    }
                }

                // Cancel an event
                Console.WriteLine("\nCanceling an Event:");
                scheduler.CancelEvent("Client Visit: Animal Health & Nutrition Launch");

                // Display all events after cancellation
                Console.WriteLine("\nAll Events After Cancellation:");
                var allEvents = scheduler.GetAllEvents();
                if (allEvents.Count == 0)
                {
                    Console.WriteLine("No events scheduled.");
                }
                else
                {
                    foreach (var evt in allEvents)
                    {
                        Console.WriteLine($" - {evt}");
                    }
                }

                Console.WriteLine("\nEvents saved to 'events.json' ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
