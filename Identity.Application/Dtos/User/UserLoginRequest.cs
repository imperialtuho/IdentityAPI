using System.Runtime.Serialization;

namespace Identity.Application.Dtos.User
{
    [DataContract]
    public class UserLoginRequest
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool IsRemember { get; set; }
    }
}