using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace ProjectKapwa.Models
{
    public class WorkAcceptance
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string partition { get; set; }

        [JsonProperty]
        public string partitionName { get; set; }

        public formdata Formdata { get; set; }
    }

    public class formdata
    {

        [JsonProperty]
        public string date { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public string position { get; set; }
        [JsonProperty]
        public string WorkOrderNo { get; set; }
        [JsonProperty]
        public string detailsOfActivity { get; set; }
        [JsonProperty]
        public string clientRemarks { get; set; }
        [JsonProperty]
        public bool Billable { get; set; }
        [JsonProperty]
        public bool OriginalScope { get; set; }

        public client Client { get; set; }
        public time TimeLog { get; set; }
        public consultant Consultant { get; set; }
        public projectManager ProjectManager { get; set; }
        public acceptedBy AcceptedBy { get; set; }
    }

    public class time
    {
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
    }
    public class client
    {
        public string name { get; set; }
        public string address { get; set; }
    }
    public class consultant
    {
        public string name { get; set; }
        public string signature { get; set; }
    }
    public class projectManager
    {
        public string name { get; set; }
        public string signature { get; set; }
    }
    public class acceptedBy
    {
        public string name { get; set; }
        public string signature { get; set; }
    }
}