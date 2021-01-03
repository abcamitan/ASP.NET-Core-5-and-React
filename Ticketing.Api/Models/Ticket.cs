using System;
using Newtonsoft.Json;

namespace Ticketing.Api.Models
{
    public class Ticket
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime WhenNeeded { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RequestedBy { get; set; }
        public Category Category { get; set; }
        public Job Job { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
    }

    public class Job
    {
        public string Status { get; set; }
        public string Activity { get; set; }
        public string AssignedTo { get; set; }
        public DateTime WhenCompleted { get; set; }
    }
}