
namespace ClientApp {
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("HttpClient Forms Authentication Example.");

            try {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["base_address"]);

                //login
                Console.WriteLine("Loggin in....");
                client.PostAsync("Account/Login",
                    new FormUrlEncodedContent(new Dictionary<string, string> { { "UserName", "amiralles" }, { "Password", "amiralles" } }))
                        .ContinueWith(response => {
                            response.Result.EnsureSuccessStatusCode();
                            Console.WriteLine("Loging ok....");

                            //Get Operation
                            GetProducts(client);
                        });
            }
            catch (Exception ex) {
                Console.WriteLine(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

            Console.ReadLine();
        }

        private static void GetProducts(HttpClient client) {
            client.GetAsync("product/all")
            .ContinueWith(res => {
                var result = res.Result;
                result.EnsureSuccessStatusCode();
                result.Content.ReadAsStringAsync()
                    .ContinueWith(response => {
                        Console.WriteLine(response.Result);
                    });
            });

            //Post Opertaion
            UpdateStock(client, "1", "200");
        }

        private static void UpdateStock(HttpClient client, string productId, string unitsInStock) {
            client.PostAsync("product/update",
                    new FormUrlEncodedContent(new Dictionary<string, string> {
                    { "Id", productId }, 
                    { "UnitsInStock", unitsInStock }
                }))
                .ContinueWith(response => {
                    response.Result.EnsureSuccessStatusCode();
                });

            //...
        }
    }
}
