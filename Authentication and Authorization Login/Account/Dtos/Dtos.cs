namespace Account.Dtos
{
   public record LoginDto(string UserName,string Password);
   public record RegisterDto(
       string Address,
       string Email,
       DateTime BirthDate,
       string UserName,
       string Password);

    public record TokenDto(string token);
}
