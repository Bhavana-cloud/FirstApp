// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RestSharp;

Console.WriteLine("Hello, World!");


RestClient client = new RestClient();   
RestRequest req1 = new RestRequest("https://localhost:7082/api/Name/authenticate", Method.Post);
req1.AddJsonBody(new
{
username = "test1",
password = "password1"
});

var response1 = client.Execute(req1);
var token = JsonConvert.DeserializeObject<string>(response1.Content);
Console.WriteLine(token);
//REquest 2 - call Authorized PI BY Attaching the token
RestRequest req2 = new RestRequest("https://localhost:7082/api/Name", Method.Get);
client.AddDefaultHeader("Authorization", $"Bearer {token}");

var response2 = client.Execute(req2).Content;
//var content = response2.Content; 
Console.WriteLine(response2);
Console.ReadLine();//type enter to exit application

