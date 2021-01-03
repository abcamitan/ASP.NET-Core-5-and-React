using Newtonsoft.Json;

namespace Ticketing.Api.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Department { get; set; }
        public string GroupName { get; set; }
    }
}
