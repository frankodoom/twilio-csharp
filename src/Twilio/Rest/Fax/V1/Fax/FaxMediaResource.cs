using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Fax.V1.Fax 
{

    /// <summary>
    /// FaxMediaResource
    /// </summary>
    public class FaxMediaResource : Resource 
    {
        private static Request BuildFetchRequest(FetchFaxMediaOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Fax,
                "/v1/Faxes/" + options.PathFaxSid + "/Media/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch FaxMedia parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FaxMedia </returns> 
        public static FaxMediaResource Fetch(FetchFaxMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch FaxMedia parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FaxMedia </returns> 
        public static async System.Threading.Tasks.Task<FaxMediaResource> FetchAsync(FetchFaxMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FaxMedia </returns> 
        public static FaxMediaResource Fetch(string pathFaxSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchFaxMediaOptions(pathFaxSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FaxMedia </returns> 
        public static async System.Threading.Tasks.Task<FaxMediaResource> FetchAsync(string pathFaxSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchFaxMediaOptions(pathFaxSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadFaxMediaOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Fax,
                "/v1/Faxes/" + options.PathFaxSid + "/Media",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read FaxMedia parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FaxMedia </returns> 
        public static ResourceSet<FaxMediaResource> Read(ReadFaxMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<FaxMediaResource>.FromJson("media", response.Content);
            return new ResourceSet<FaxMediaResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read FaxMedia parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FaxMedia </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<FaxMediaResource>> ReadAsync(ReadFaxMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<FaxMediaResource>.FromJson("media", response.Content);
            return new ResourceSet<FaxMediaResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FaxMedia </returns> 
        public static ResourceSet<FaxMediaResource> Read(string pathFaxSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadFaxMediaOptions(pathFaxSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FaxMedia </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<FaxMediaResource>> ReadAsync(string pathFaxSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadFaxMediaOptions(pathFaxSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<FaxMediaResource> NextPage(Page<FaxMediaResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Fax,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<FaxMediaResource>.FromJson("media", response.Content);
        }

        private static Request BuildDeleteRequest(DeleteFaxMediaOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Fax,
                "/v1/Faxes/" + options.PathFaxSid + "/Media/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete FaxMedia parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FaxMedia </returns> 
        public static bool Delete(DeleteFaxMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete FaxMedia parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FaxMedia </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteFaxMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FaxMedia </returns> 
        public static bool Delete(string pathFaxSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFaxMediaOptions(pathFaxSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FaxMedia </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathFaxSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFaxMediaOptions(pathFaxSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a FaxMediaResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FaxMediaResource object represented by the provided JSON </returns> 
        public static FaxMediaResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<FaxMediaResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The fax_sid
        /// </summary>
        [JsonProperty("fax_sid")]
        public string FaxSid { get; private set; }
        /// <summary>
        /// The content_type
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private FaxMediaResource()
        {

        }
    }

}