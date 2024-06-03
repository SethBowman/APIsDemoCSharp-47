
using Newtonsoft.Json.Linq;


//Create an instance of a class called HTTPClient, this is what actually makes the API call
var client = new HttpClient();

//Build an api url from where the api call comes from
var kanyeURL = "https://api.kanye.rest/";

//Using the HTTPClient instance 
//Send a GET request to the url created above, this is going to give us back a string of json
var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

//Parse the json response we just got back into a JObject, we do this so we can access certain pieces/parts of the json
//In this case we will be getting the value of the name "quote" which will give us the actual quote itself and not the whole body of json
//Without ToString() it will be of type JToken, so we could never use it as a string

//var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();

Console.WriteLine(kanyeQuote);

//USING APPSETTINGS/API KEY SECTION

//Grab appsettings file and the text it contains
var appsettingsText = File.ReadAllText("appsettings.json");

//Get the api key from the appsettings text using it's name/key ("apiKey")
var apiKey = JObject.Parse(appsettingsText)["apiKey"].ToString();

var url = $"http://api.openweathermap.org/data/2.5/weather?zip=35091&appid={apiKey}&units=imperial";