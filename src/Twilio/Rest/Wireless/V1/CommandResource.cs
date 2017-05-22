using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Wireless.V1 
{

    /// <summary>
    /// CommandResource
    /// </summary>
    public class CommandResource : Resource 
    {
        public sealed class DirectionEnum : StringEnum 
        {
            private DirectionEnum(string value) : base(value) {}
            public DirectionEnum() {}

            public static readonly DirectionEnum FromSim = new DirectionEnum("from_sim");
            public static readonly DirectionEnum ToSim = new DirectionEnum("to_sim");
        }

        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}

            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Sent = new StatusEnum("sent");
            public static readonly StatusEnum Delivered = new StatusEnum("delivered");
            public static readonly StatusEnum Received = new StatusEnum("received");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
        }

        public sealed class CommandModeEnum : StringEnum 
        {
            private CommandModeEnum(string value) : base(value) {}
            public CommandModeEnum() {}

            public static readonly CommandModeEnum Text = new CommandModeEnum("text");
            public static readonly CommandModeEnum Binary = new CommandModeEnum("binary");
        }

        private static Request BuildFetchRequest(FetchCommandOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Wireless,
                "/v1/Commands/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Command parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Command </returns> 
        public static CommandResource Fetch(FetchCommandOptions options, ITwilioRestClient client = null)
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
        /// <param name="options"> Fetch Command parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Command </returns> 
        public static async System.Threading.Tasks.Task<CommandResource> FetchAsync(FetchCommandOptions options, ITwilioRestClient client = null)
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
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Command </returns> 
        public static CommandResource Fetch(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchCommandOptions(pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Command </returns> 
        public static async System.Threading.Tasks.Task<CommandResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchCommandOptions(pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadCommandOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Wireless,
                "/v1/Commands",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Command parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Command </returns> 
        public static ResourceSet<CommandResource> Read(ReadCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<CommandResource>.FromJson("commands", response.Content);
            return new ResourceSet<CommandResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Command parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Command </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<CommandResource>> ReadAsync(ReadCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<CommandResource>.FromJson("commands", response.Content);
            return new ResourceSet<CommandResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="sim"> The sim </param>
        /// <param name="status"> The status </param>
        /// <param name="direction"> The direction </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Command </returns> 
        public static ResourceSet<CommandResource> Read(string sim = null, CommandResource.StatusEnum status = null, CommandResource.DirectionEnum direction = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCommandOptions{Sim = sim, Status = status, Direction = direction, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="sim"> The sim </param>
        /// <param name="status"> The status </param>
        /// <param name="direction"> The direction </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Command </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<CommandResource>> ReadAsync(string sim = null, CommandResource.StatusEnum status = null, CommandResource.DirectionEnum direction = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCommandOptions{Sim = sim, Status = status, Direction = direction, PageSize = pageSize, Limit = limit};
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
        public static Page<CommandResource> NextPage(Page<CommandResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Wireless,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<CommandResource>.FromJson("commands", response.Content);
        }

        private static Request BuildCreateRequest(CreateCommandOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Wireless,
                "/v1/Commands",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Command parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Command </returns> 
        public static CommandResource Create(CreateCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Command parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Command </returns> 
        public static async System.Threading.Tasks.Task<CommandResource> CreateAsync(CreateCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="command"> The command </param>
        /// <param name="sim"> The sim </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="commandMode"> The command_mode </param>
        /// <param name="includeSid"> The include_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Command </returns> 
        public static CommandResource Create(string command, string sim = null, Twilio.Http.HttpMethod callbackMethod = null, Uri callbackUrl = null, CommandResource.CommandModeEnum commandMode = null, string includeSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCommandOptions(command){Sim = sim, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, CommandMode = commandMode, IncludeSid = includeSid};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="command"> The command </param>
        /// <param name="sim"> The sim </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="commandMode"> The command_mode </param>
        /// <param name="includeSid"> The include_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Command </returns> 
        public static async System.Threading.Tasks.Task<CommandResource> CreateAsync(string command, string sim = null, Twilio.Http.HttpMethod callbackMethod = null, Uri callbackUrl = null, CommandResource.CommandModeEnum commandMode = null, string includeSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCommandOptions(command){Sim = sim, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, CommandMode = commandMode, IncludeSid = includeSid};
            return await CreateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a CommandResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CommandResource object represented by the provided JSON </returns> 
        public static CommandResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CommandResource>(json);
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
        /// The sim_sid
        /// </summary>
        [JsonProperty("sim_sid")]
        public string SimSid { get; private set; }
        /// <summary>
        /// The command
        /// </summary>
        [JsonProperty("command")]
        public string Command { get; private set; }
        /// <summary>
        /// The command_mode
        /// </summary>
        [JsonProperty("command_mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandResource.CommandModeEnum CommandMode { get; private set; }
        /// <summary>
        /// The status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// The direction
        /// </summary>
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandResource.DirectionEnum Direction { get; private set; }
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

        private CommandResource()
        {

        }
    }

}