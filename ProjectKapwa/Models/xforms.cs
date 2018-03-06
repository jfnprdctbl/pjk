using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ProjectKapwa.Models
{
    public class xforms
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "category")]
        public string Partition { get; set; }

        public fullName FullName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class fullName
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
    }

}