using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using List3.Models;
using RestSharp;

namespace List3.Commands
{
    public static class Database
    {
        private static RestClient client = new RestClient("https://localhost:7017");

        public static async Task<ObservableCollection<Car>> GetData()
        {
            var request = new RestRequest("api/Cars", Method.Get);
            var response = await client.ExecuteAsync(request);
            ObservableCollection<Car> cars = new ObservableCollection<Car>();

            if (response.IsSuccessful)
            {
                var carsList = JsonSerializer.Deserialize<List<Car>>(response.Content);
                foreach (var car in carsList)
                {
                    cars.Add(car);
                }
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}");
            }

            return cars;
        }

        public static async Task AddCarToDatabase(Car car)
        {
            var request = new RestRequest("api/Cars", Method.Post);
            var json = JsonSerializer.Serialize(car);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Successfully added");
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
            }
        }
       
        public static async Task EditCar(Car car)
        {
            var request = new RestRequest($"api/Cars/{car.Id}", Method.Put);
            var json = JsonSerializer.Serialize(car);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Successfully updated");
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
            }
        }

        public static async Task DeleteCar(Car car)
        {
            var request = new RestRequest($"api/Cars/{car.Id}", Method.Delete);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Successfully deleted");
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
            }
        }

        public static async Task<ObservableCollection<Car>> GetAvailableCars()
        {
            var request = new RestRequest("api/Cars/available", Method.Get);
            var response = await client.ExecuteAsync(request);
            ObservableCollection<Car> availableCars = new ObservableCollection<Car>();

            if (response.IsSuccessful)
            {
                var carsList = JsonSerializer.Deserialize<List<Car>>(response.Content);
                foreach (var car in carsList)
                {
                    availableCars.Add(car);
                }
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
            }

            return availableCars;
        }

        public static async Task<bool> AddRentalToDatabase(Rental rental)
        {
            var request = new RestRequest("api/Rentals", Method.Post);
            var json = JsonSerializer.Serialize(rental);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
                return false;
            }
        }

        public static async Task<ObservableCollection<Rental>> GetRentals()
        {
            var request = new RestRequest("api/Rentals", Method.Get);
            var response = await client.ExecuteAsync(request);
            ObservableCollection<Rental> rentals = new ObservableCollection<Rental>();

            if (response.IsSuccessful)
            {
                var rentalsList = JsonSerializer.Deserialize<List<Rental>>(response.Content,
                   new JsonSerializerOptions
                   {
                       PropertyNameCaseInsensitive = true
                   });

                foreach (var rental in rentalsList)
                {
                    rentals.Add(rental);
                }
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
            }

            return rentals;
        }

        public static async Task DeleteRental(Rental rental)
        {
            var request = new RestRequest($"api/Rentals/{rental.Id}", Method.Delete);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Successfully deleted");
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
            }
        }

        public static async Task<bool> UpdateRentalEndDate(int rentalId, DateTime newEndDate)
        {
            var request = new RestRequest($"api/Rentals/{rentalId}", Method.Put);
            var json = JsonSerializer.Serialize(newEndDate);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Successfully updated date");
                return true;
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}, {response.Content}");
                return false;
            }
        }
    }
}
