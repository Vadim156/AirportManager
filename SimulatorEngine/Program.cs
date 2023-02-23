using SimulatorEngine;
using System.Net.Http.Json;

HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:44386") };
Random rnd = new Random();

System.Timers.Timer timer = new System.Timers.Timer(8500);
timer.Elapsed += (s, e) => PostPlan();
timer.Start();




Console.ReadLine();

async void PostPlan()
{

    Random rnd = new Random();
    var Flight = new FlightDto()
    {
        IsDeparture = false,
        Brand = (BrandTypeDto)rnd.Next(0, 3),
        PassengersCount = rnd.Next(100, 700),
        FlightId = Guid.NewGuid().ToString(),
        SerialNumber = Guid.NewGuid().ToString()
    };
    await client.PostAsJsonAsync("api/Flights/Post", Flight);

    Console.WriteLine("Running");
}

