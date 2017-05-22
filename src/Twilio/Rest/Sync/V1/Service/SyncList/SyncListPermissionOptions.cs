using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Sync.V1.Service.SyncList 
{

    /// <summary>
    /// Fetch a specific Sync List Permission.
    /// </summary>
    public class FetchSyncListPermissionOptions : IOptions<SyncListPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync List SID or unique name.
        /// </summary>
        public string PathListSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync List Permission applies.
        /// </summary>
        public string PathIdentity { get; }

        /// <summary>
        /// Construct a new FetchSyncListPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathListSid"> Sync List SID or unique name. </param>
        /// <param name="pathIdentity"> Identity of the user to whom the Sync List Permission applies. </param>
        public FetchSyncListPermissionOptions(string pathServiceSid, string pathListSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIdentity = pathIdentity;
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
    /// Delete a specific Sync List Permission.
    /// </summary>
    public class DeleteSyncListPermissionOptions : IOptions<SyncListPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync List SID or unique name.
        /// </summary>
        public string PathListSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync List Permission applies.
        /// </summary>
        public string PathIdentity { get; }

        /// <summary>
        /// Construct a new DeleteSyncListPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathListSid"> Sync List SID or unique name. </param>
        /// <param name="pathIdentity"> Identity of the user to whom the Sync List Permission applies. </param>
        public DeleteSyncListPermissionOptions(string pathServiceSid, string pathListSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIdentity = pathIdentity;
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
    /// Retrieve a list of all Permissions applying to a Sync List.
    /// </summary>
    public class ReadSyncListPermissionOptions : ReadOptions<SyncListPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync List SID or unique name.
        /// </summary>
        public string PathListSid { get; }

        /// <summary>
        /// Construct a new ReadSyncListPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathListSid"> Sync List SID or unique name. </param>
        public ReadSyncListPermissionOptions(string pathServiceSid, string pathListSid)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// Update an identity's access to a specific Sync List.
    /// </summary>
    public class UpdateSyncListPermissionOptions : IOptions<SyncListPermissionResource> 
    {
        /// <summary>
        /// Sync Service Instance SID.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync List SID or unique name.
        /// </summary>
        public string PathListSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync List Permission applies.
        /// </summary>
        public string PathIdentity { get; }
        /// <summary>
        /// Read access.
        /// </summary>
        public bool? Read { get; }
        /// <summary>
        /// Write access.
        /// </summary>
        public bool? Write { get; }
        /// <summary>
        /// Manage access.
        /// </summary>
        public bool? Manage { get; }

        /// <summary>
        /// Construct a new UpdateSyncListPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Sync Service Instance SID. </param>
        /// <param name="pathListSid"> Sync List SID or unique name. </param>
        /// <param name="pathIdentity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        public UpdateSyncListPermissionOptions(string pathServiceSid, string pathListSid, string pathIdentity, bool? read, bool? write, bool? manage)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIdentity = pathIdentity;
            Read = read;
            Write = write;
            Manage = manage;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Read != null)
            {
                p.Add(new KeyValuePair<string, string>("Read", Read.Value.ToString()));
            }

            if (Write != null)
            {
                p.Add(new KeyValuePair<string, string>("Write", Write.Value.ToString()));
            }

            if (Manage != null)
            {
                p.Add(new KeyValuePair<string, string>("Manage", Manage.Value.ToString()));
            }

            return p;
        }
    }

}