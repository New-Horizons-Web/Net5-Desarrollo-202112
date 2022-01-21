using System;

namespace Net5.Security.Cross_Site_Request_Forgery.Attacker.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
