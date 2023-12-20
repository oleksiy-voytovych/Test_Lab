using lab_3.Support;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecFlow.Internal.Json;
using System.Net;
using System.Security.Policy;

namespace lab_3.StepDefinitions
{
    [Binding]
    public class Booking : Client
    {
        

        public BookingObject bookingObject { get; set; }
        public string token { get; set; }

        [When(@"I send a GET request to ""([^""]*)""")]
        public void WhenISendAGETRequestTo(string url)
        {
            client = new RestClient(url);

            request = new RestRequest();

            request.Method = Method.Get;

            response = client.Execute(request);

        }
        


        [Then(@"the response status code should OK")]
        public void ThenTheResponseStatusCodeShouldOK()
        {
            if (response.StatusCode != HttpStatusCode.OK) { Assert.Fail(); }
            
            //Assert.Pass();
        }

        [When(@"I send a POST request to ""([^""]*)"" with details ""([^""]*)"" and ""([^""]*)""")]
        public void WhenISendAPOSTRequestToWithDetailsAnd(string url, string name_value, string password_value)
        {
            client = new RestClient(url);

            request = new RestRequest();

            request.Method = Method.Post;

            var requestBody = new
            {
                username = name_value,
                password = password_value
            };

            request.AddBody(requestBody);
            response = client.Execute(request);
            token = JsonConvert.DeserializeObject<TokenModel>(response.Content).Token;
            Console.WriteLine(response.Content);
        }

        [When(@"I create a booking with id:(.*)")]
        public void WhenICreateABookingWithId(int booking_id)
        {
            bookingObject = new BookingObject(booking_id);
        }

        [When(@"I send a PUT request to ""([^""]*)"" with this booking")]
        public void WhenISendAPUTRequestToWithThisBooking(string url)
        {


            client = new RestClient(url.Replace(":id", bookingObject.GetId().ToString()));


            request = new RestRequest();

            request.Method = Method.Put;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cookie", $"token={token}");

            var requestBody = new
            {

                firstname = bookingObject.GetFirstname(),
                lastname = bookingObject.GetLastname(),
                totalprice = bookingObject.GetTotalprice(),
                depositpaid = bookingObject.GetDepositpaid(),
                bookingdates = new
                {
                    checkin = bookingObject.GetCheckin(),
                    checkout = bookingObject.GetCheckout()
                },
                additionalneeds = "UpdatedBreakfast"
            };

            request.AddJsonBody(requestBody);
            response = client.Execute(request);
        }

        [When(@"I send a Delete request to ""([^""]*)"" with a booking id:(.*)")]
        public void WhenISendADeleteRequestToWithABookingId(string url, int id)
        {
            client = new RestClient(url.Replace(":id", id.ToString()));
            request = new RestRequest();

            request.Method = Method.Delete;
            
            request.AddHeader("Cookie", $"token={token}");

            response = client.Execute(request);

        }
        [Then(@"the response status code should be COMPLETED")]
        public void ThenTheResponseStatusCodeShouldBeCOMPLETED()
        {
            if (response.StatusCode != HttpStatusCode.Created) { Assert.Fail(); }
        }



        [Given(@"Booking with details:(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenBookingWithDetails(string totalprice, string depositpaid, string checkin, string checkout, string firstname, string lastname)
        {
            bookingObject = new BookingObject(firstname, lastname, totalprice, bool.Parse(depositpaid), checkin, checkout);
        }

        [When(@"I send a POST request to ""([^""]*)"" with selected booking details")]
        public void WhenISendAPOSTRequestToWithSelectedBookingDetails(string url)
        {
            client = new RestClient(url);

            request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var requestBody = new
            {

                firstname = bookingObject.GetFirstname(),
                lastname = bookingObject.GetLastname(),
                totalprice = bookingObject.GetTotalprice(),
                depositpaid = bookingObject.GetDepositpaid(),
                bookingdates = new
                {
                    checkin = bookingObject.GetCheckin(),
                    checkout = bookingObject.GetCheckout()
                },
                additionalneeds = "Breakfast"
            };
            request.AddJsonBody(requestBody);

            response = client.Execute(request);
        }


    }
}