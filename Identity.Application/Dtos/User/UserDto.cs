namespace Identity.Application.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}