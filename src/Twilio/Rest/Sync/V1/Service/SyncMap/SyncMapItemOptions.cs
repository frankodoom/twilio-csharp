using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Sync.V1.Service.SyncMap 
{

    /// <summary>
    /// FetchSyncMapItemOptions
    /// </summary>
    public class FetchSyncMapItemOptions : IOptions<SyncMapItemResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The map_sid
        /// </summary>
        public string PathMapSid { get; }
        /// <summary>
        /// The key
        /// </summary>
        public string PathKey { get; }

        /// <summary>
        /// Construct a new FetchSyncMapItemOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathMapSid"> The map_sid </param>
        /// <param name="pathKey"> The key </param>
        public FetchSyncMapItemOptions(string pathServiceSid, string pathMapSid, string pathKey)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            PathKey = pathKey;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// DeleteSyncMapItemOptions
    /// </summary>
    public class DeleteSyncMapItemOptions : IOptions<SyncMapItemResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The map_sid
        /// </summary>
        public string PathMapSid { get; }
        /// <summary>
        /// The key
        /// </summary>
        public string PathKey { get; }

        /// <summary>
        /// Construct a new DeleteSyncMapItemOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathMapSid"> The map_sid </param>
        /// <param name="pathKey"> The key </param>
        public DeleteSyncMapItemOptions(string pathServiceSid, string pathMapSid, string pathKey)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            PathKey = pathKey;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// CreateSyncMapItemOptions
    /// </summary>
    public class CreateSyncMapItemOptions : IOptions<SyncMapItemResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The map_sid
        /// </summary>
        public string PathMapSid { get; }
        /// <summary>
        /// The key
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// The data
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Construct a new CreateSyncMapItemOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathMapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <param name="data"> The data </param>
        public CreateSyncMapItemOptions(string pathServiceSid, string pathMapSid, string key, object data)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            Key = key;
            Data = data;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Key != null)
            {
                p.Add(new KeyValuePair<string, string>("Key", Key));
            }

            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Serializers.JsonObject(Data)));
            }

            return p;
        }
    }

    /// <summary>
    /// ReadSyncMapItemOptions
    /// </summary>
    public class ReadSyncMapItemOptions : ReadOptions<SyncMapItemResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The map_sid
        /// </summary>
        public string PathMapSid { get; }
        /// <summary>
        /// The order
        /// </summary>
        public SyncMapItemResource.QueryResultOrderEnum Order { get; set; }
        /// <summary>
        /// The from
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// The bounds
        /// </summary>
        public SyncMapItemResource.QueryFromBoundTypeEnum Bounds { get; set; }

        /// <summary>
        /// Construct a new ReadSyncMapItemOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathMapSid"> The map_sid </param>
        public ReadSyncMapItemOptions(string pathServiceSid, string pathMapSid)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Order != null)
            {
                p.Add(new KeyValuePair<string, string>("Order", Order.ToString()));
            }

            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }

            if (Bounds != null)
            {
                p.Add(new KeyValuePair<string, string>("Bounds", Bounds.ToString()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// UpdateSyncMapItemOptions
    /// </summary>
    public class UpdateSyncMapItemOptions : IOptions<SyncMapItemResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The map_sid
        /// </summary>
        public string PathMapSid { get; }
        /// <summary>
        /// The key
        /// </summary>
        public string PathKey { get; }
        /// <summary>
        /// The data
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Construct a new UpdateSyncMapItemOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathMapSid"> The map_sid </param>
        /// <param name="pathKey"> The key </param>
        /// <param name="data"> The data </param>
        public UpdateSyncMapItemOptions(string pathServiceSid, string pathMapSid, string pathKey, object data)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            PathKey = pathKey;
            Data = data;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Serializers.JsonObject(Data)));
            }

            return p;
        }
    }

}