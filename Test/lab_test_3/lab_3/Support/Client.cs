using RestSharp;
using RestSharp.Serializers.Json;
using RestSharp.Authenticators;

namespace lab_3.Support
{
    public class Client
    {
        public static RestClient client = new RestClient();
        public static RestRequest request = new RestRequest();
        public static RestResponse response { get; set; }
        public Client() { }
    }
}
