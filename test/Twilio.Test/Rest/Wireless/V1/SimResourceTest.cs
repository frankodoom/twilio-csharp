using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Wireless.V1;

namespace Twilio.Tests.Rest.Wireless.V1 
{

    [TestFixture]
    public class SimTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Wireless,
                "/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                SimResource.Fetch("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"unique_name\": \"unique_name\",\"commands_callback_method\": \"http_method\",\"commands_callback_url\": \"http://www.example.com\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"friendly_name\": \"friendly_name\",\"sms_fallback_method\": \"http_method\",\"sms_fallback_url\": \"http://www.example.com\",\"sms_method\": \"http_method\",\"sms_url\": \"http://www.example.com\",\"voice_fallback_method\": \"http_method\",\"voice_fallback_url\": \"http://www.example.com\",\"voice_method\": \"http_method\",\"voice_url\": \"http://www.example.com\",\"links\": {\"rate_plan\": \"https://wireless.twilio.com/v1/RatePlans/WPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_records\": \"https://wireless.twilio.com/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/UsageRecords\"},\"rate_plan_sid\": \"WPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"iccid\",\"e_id\": \"e_id\",\"status\": \"new\",\"url\": \"https://wireless.twilio.com/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = SimResource.Fetch("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Wireless,
                "/v1/Sims",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                SimResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"sims\": [],\"meta\": {\"first_page_url\": \"https://wireless.twilio.com/v1/Sims?PageSize=50&Page=0\",\"key\": \"sims\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://wireless.twilio.com/v1/Sims?PageSize=50&Page=0\"}}"
                                     ));

            var response = SimResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"sims\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"unique_name\": \"unique_name\",\"commands_callback_method\": \"http_method\",\"commands_callback_url\": \"http://www.example.com\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"friendly_name\": \"friendly_name\",\"links\": {\"rate_plan\": \"https://wireless.twilio.com/v1/RatePlans/WPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_records\": \"https://wireless.twilio.com/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/UsageRecords\"},\"rate_plan_sid\": \"WPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"iccid\",\"e_id\": \"e_id\",\"status\": \"new\",\"sms_fallback_method\": \"http_method\",\"sms_fallback_url\": \"http://www.example.com\",\"sms_method\": \"http_method\",\"sms_url\": \"http://www.example.com\",\"voice_fallback_method\": \"http_method\",\"voice_fallback_url\": \"http://www.example.com\",\"voice_method\": \"http_method\",\"voice_url\": \"http://www.example.com\",\"url\": \"https://wireless.twilio.com/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://wireless.twilio.com/v1/Sims?PageSize=50&Page=0\",\"key\": \"sims\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://wireless.twilio.com/v1/Sims?PageSize=50&Page=0\"}}"
                                     ));

            var response = SimResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Wireless,
                "/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                SimResource.Update("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestUpdateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"unique_name\": \"unique_name\",\"commands_callback_method\": \"http_method\",\"commands_callback_url\": \"http://www.example.com\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"friendly_name\": \"friendly_name\",\"links\": {\"rate_plan\": \"https://wireless.twilio.com/v1/RatePlans/WPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_records\": \"https://wireless.twilio.com/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/UsageRecords\"},\"rate_plan_sid\": \"WPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"iccid\",\"e_id\": \"e_id\",\"status\": \"new\",\"sms_fallback_method\": \"http_method\",\"sms_fallback_url\": \"http://www.example.com\",\"sms_method\": \"http_method\",\"sms_url\": \"http://www.example.com\",\"voice_fallback_method\": \"http_method\",\"voice_fallback_url\": \"http://www.example.com\",\"voice_method\": \"http_method\",\"voice_url\": \"http://www.example.com\",\"url\": \"https://wireless.twilio.com/v1/Sims/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = SimResource.Update("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}