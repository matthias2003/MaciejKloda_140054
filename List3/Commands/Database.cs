using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using List3.Models;
using RestSharp;

namespace List3.Commands
{
    public static class Database
    {
        private static RestClient client = new RestClient("https://localhost:7017");

        public static ObservableCollection<Car> GetData()
        {
            var request = new RestRequest("api/Cars", Method.Get);
            var response = client.Execute(request);
            ObservableCollection<Car> Cars = new ObservableCollection<Car>();

            if (response.IsSuccessful)
            {
                var carsList = JsonSerializer.Deserialize<List<Car>>(response.Content);
                foreach (var car in carsList)
                {
                    Cars.Add(car);
                }
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}");
            }

            return Cars;
        }

        public static void AddCarToDatabase(Car car)
        {
            var request = new RestRequest("api/Cars", Method.Post);
            var json = JsonSerializer.Serialize(car);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Pomyślnie dodano samochód!");
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
            }
        }

        public static void EditCar(Car car)
        {
            var request = new RestRequest($"api/Cars/{car.Id}", Method.Put);

            var json = JsonSerializer.Serialize(car);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Pomyślnie dodano samochód!");
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
            }
        }

        public static void DeleteCar(Car car)
        {
            var request = new RestRequest($"api/Cars/{car.Id}", Method.Delete);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Pomyślnie usunięto samochód!");
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
            }
        }

        public static ObservableCollection<Car> GetAvailableCars()
        {
            var request = new RestRequest("api/Cars/available", Method.Get);
            var response = client.Execute(request);
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
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
            }

            return availableCars;
        }
        public static bool AddRentalToDatabase(Rental rental)
        {
            var request = new RestRequest("api/Rentals", Method.Post);
            var json = JsonSerializer.Serialize(rental);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return true;
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
                return false;
            }
        }

        public static ObservableCollection<Rental> GetRentals()
        {
            var request = new RestRequest("api/Rentals", Method.Get);
            var response = client.Execute(request);
            ObservableCollection<Rental> rentals = new ObservableCollection<Rental>();

            if (response.IsSuccessful)
            {
                Debug.WriteLine($"Response Content: {response.Content}");
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
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
            }

            return rentals;
        }

        public static void DeleteRental(Rental rental)
        {
            var request = new RestRequest($"api/Rentals/{rental.Id}", Method.Delete);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Pomyślnie usunięto rental!");
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
            }
        }

        public static bool UpdateRentalEndDate(int rentalId, DateTime newEndDate)
        {
            var request = new RestRequest($"api/Rentals/{rentalId}", Method.Put);

            var json = JsonSerializer.Serialize(newEndDate);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Debug.WriteLine("Pomyślnie zaktualizowano datę zakończenia wynajmu.");
                return true;
            }
            else
            {
                Debug.WriteLine($"Błąd: {response.StatusCode}, {response.Content}");
                return false;
            }
        }
    }

}
