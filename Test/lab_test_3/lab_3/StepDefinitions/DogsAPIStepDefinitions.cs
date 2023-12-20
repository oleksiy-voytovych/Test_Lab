using System;
using TechTalk.SpecFlow;
using lab_3.Support;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Gherkin.CucumberMessages.Types;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;

namespace lab_3.StepDefinitions
{
    [Binding]
    public class DogsAPIStepDefinitions: Client
    {
        [Then(@"the response status should ""([^""]*)""")]
        public void ThenTheResponseStatusShould(string success)
        {
            //Console.WriteLine($"{response.Content}\nResponce status code : {response.StatusCode}\n");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [When(@"I get a reponce message")]
        public void WhenIGetAReponceMessage()
        {
            JObject json = JObject.Parse(response.Content);
            Console.WriteLine(json.GetValue("message"));
        }

    }
}
