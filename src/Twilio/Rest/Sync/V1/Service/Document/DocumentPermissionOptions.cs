using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Sync.V1.Service.Document 
{

    /// <summary>
    /// Fetch a specific Sync Document Permission.
    /// </summary>
    public class FetchDocumentPermissionOptions : IOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string PathDocumentSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
        /// </summary>
        public string PathIdentity { get; }

        /// <summary>
        /// Construct a new FetchDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathDocumentSid"> Sync Document SID or unique name. </param>
        /// <param name="pathIdentity"> Identity of the user to whom the Sync Document Permission applies. </param>
        public FetchDocumentPermissionOptions(string pathServiceSid, string pathDocumentSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathDocumentSid = pathDocumentSid;
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
    /// Delete a specific Sync Document Permission.
    /// </summary>
    public class DeleteDocumentPermissionOptions : IOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string PathDocumentSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
        /// </summary>
        public string PathIdentity { get; }

        /// <summary>
        /// Construct a new DeleteDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathDocumentSid"> Sync Document SID or unique name. </param>
        /// <param name="pathIdentity"> Identity of the user to whom the Sync Document Permission applies. </param>
        public DeleteDocumentPermissionOptions(string pathServiceSid, string pathDocumentSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathDocumentSid = pathDocumentSid;
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
    /// Retrieve a list of all Permissions applying to a Sync Document.
    /// </summary>
    public class ReadDocumentPermissionOptions : ReadOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string PathDocumentSid { get; }

        /// <summary>
        /// Construct a new ReadDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathDocumentSid"> Sync Document SID or unique name. </param>
        public ReadDocumentPermissionOptions(string pathServiceSid, string pathDocumentSid)
        {
            PathServiceSid = pathServiceSid;
            PathDocumentSid = pathDocumentSid;
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
    /// Update an identity's access to a specific Sync Document.
    /// </summary>
    public class UpdateDocumentPermissionOptions : IOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// Sync Service Instance SID.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string PathDocumentSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
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
        /// Construct a new UpdateDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Sync Service Instance SID. </param>
        /// <param name="pathDocumentSid"> Sync Document SID or unique name. </param>
        /// <param name="pathIdentity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        public UpdateDocumentPermissionOptions(string pathServiceSid, string pathDocumentSid, string pathIdentity, bool? read, bool? write, bool? manage)
        {
            PathServiceSid = pathServiceSid;
            PathDocumentSid = pathDocumentSid;
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