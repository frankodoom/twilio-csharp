using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue {

    public class TaskQueuesStatisticsReader : Reader<TaskQueuesStatisticsResource> {
        public string workspaceSid { get; }
        public DateTime? endDate { get; set; }
        public string friendlyName { get; set; }
        public int? minutes { get; set; }
        public DateTime? startDate { get; set; }
    
        /// <summary>
        /// Construct a new TaskQueuesStatisticsReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public TaskQueuesStatisticsReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// The end_date
        /// </summary>
        ///
        /// <param name="endDate"> The end_date </param>
        /// <returns> this </returns> 
        public TaskQueuesStatisticsReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public TaskQueuesStatisticsReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The minutes
        /// </summary>
        ///
        /// <param name="minutes"> The minutes </param>
        /// <returns> this </returns> 
        public TaskQueuesStatisticsReader ByMinutes(int? minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /// <summary>
        /// The start_date
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <returns> this </returns> 
        public TaskQueuesStatisticsReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TaskQueuesStatisticsResource ResourceSet </returns> 
        public override Task<ResourceSet<TaskQueuesStatisticsResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/Statistics"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<TaskQueuesStatisticsResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TaskQueuesStatisticsResource ResourceSet </returns> 
        public override ResourceSet<TaskQueuesStatisticsResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/Statistics"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<TaskQueuesStatisticsResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<TaskQueuesStatisticsResource> NextPage(Page<TaskQueuesStatisticsResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of TaskQueuesStatisticsResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<TaskQueuesStatisticsResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueuesStatisticsResource read failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (minutes != null) {
                request.AddQueryParam("Minutes", minutes.ToString());
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}