using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class MessageCreator : Creator<MessageResource> 
    {
        public string accountSid { get; }
        public Twilio.Types.PhoneNumber to { get; }
        public Twilio.Types.PhoneNumber from { get; }
        public string messagingServiceSid { get; }
        public string body { get; }
        public List<Uri> mediaUrl { get; }
        public Uri statusCallback { get; set; }
        public string applicationSid { get; set; }
        public decimal? maxPrice { get; set; }
        public bool? provideFeedback { get; set; }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        public MessageCreator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body, string accountSid=null, string messagingServiceSid=null, List<Uri> mediaUrl=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            this.maxPrice = maxPrice;
            this.provideFeedback = provideFeedback;
            this.mediaUrl = mediaUrl;
            this.from = from;
            this.body = body;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.applicationSid = applicationSid;
            this.messagingServiceSid = messagingServiceSid;
            this.to = to;
        }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        public MessageCreator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl, string accountSid=null, string messagingServiceSid=null, string body=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            this.maxPrice = maxPrice;
            this.provideFeedback = provideFeedback;
            this.mediaUrl = mediaUrl;
            this.from = from;
            this.body = body;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.applicationSid = applicationSid;
            this.messagingServiceSid = messagingServiceSid;
            this.to = to;
        }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        public MessageCreator(Twilio.Types.PhoneNumber to, string messagingServiceSid, string body, string accountSid=null, Twilio.Types.PhoneNumber from=null, List<Uri> mediaUrl=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            this.maxPrice = maxPrice;
            this.provideFeedback = provideFeedback;
            this.mediaUrl = mediaUrl;
            this.from = from;
            this.body = body;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.applicationSid = applicationSid;
            this.messagingServiceSid = messagingServiceSid;
            this.to = to;
        }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        public MessageCreator(Twilio.Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl, string accountSid=null, Twilio.Types.PhoneNumber from=null, string body=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            this.maxPrice = maxPrice;
            this.provideFeedback = provideFeedback;
            this.body = body;
            this.from = from;
            this.mediaUrl = mediaUrl;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.applicationSid = applicationSid;
            this.messagingServiceSid = messagingServiceSid;
            this.to = to;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MessageResource </returns> 
        public override async Task<MessageResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Messages.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MessageResource </returns> 
        public override MessageResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Messages.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (to != null)
            {
                request.AddPostParam("To", to.ToString());
            }
            
            if (from != null)
            {
                request.AddPostParam("From", from.ToString());
            }
            
            if (messagingServiceSid != null)
            {
                request.AddPostParam("MessagingServiceSid", messagingServiceSid);
            }
            
            if (body != null)
            {
                request.AddPostParam("Body", body);
            }
            
            if (mediaUrl != null)
            {
                request.AddPostParam("MediaUrl", mediaUrl.ToString());
            }
            
            if (statusCallback != null)
            {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (applicationSid != null)
            {
                request.AddPostParam("ApplicationSid", applicationSid);
            }
            
            if (maxPrice != null)
            {
                request.AddPostParam("MaxPrice", maxPrice.ToString());
            }
            
            if (provideFeedback != null)
            {
                request.AddPostParam("ProvideFeedback", provideFeedback.ToString());
            }
        }
    }
}