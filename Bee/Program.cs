// See https://aka.ms/new-console-template for more information
using Service.DTOs.UserDTOs;
using Service.Services;


UserService service = new UserService();

UserUpdateDto userCreationDto = new UserUpdateDto()
{
    Id = 2,
    Bio="sdsffss",
    Email="shduashkdslkud@gmail.com",
    Password="passssword",
    ProfilePicture="sspath",
    Username="usernamsse",
};

var s= service.ModifyAsync(userCreationDto);
Console.WriteLine(s.Result.StatusCode);