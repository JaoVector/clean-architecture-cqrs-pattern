using Newtonsoft.Json;

namespace FollowMe.Application.Shared.Exceptions
{
    public class ErrorsMap
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
