using Identity.Common.Enums;
using System.Runtime.Serialization;

namespace Identity.Application.Dtos.User
{
    [DataContract]
    public class UserLoginResponse
    {
        [DataMember]
        public bool IsSuccessed { get; set; }

        [DataMember]
        public LoginErrorCode ErrorCode { get; set; }

        [DataMember]
        public string AccessToken { get; set; }

        [DataMember]
        public string RefreshToken { get; set; }

        [DataMember]
        public UserDto User { get; set; }
    }
}