namespace Service.DTOs.UserDTOs;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public string Bio { get; set; }
}
