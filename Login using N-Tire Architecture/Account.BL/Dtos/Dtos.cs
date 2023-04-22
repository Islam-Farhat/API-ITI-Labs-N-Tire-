namespace Account.BL
{
    public record LoginDto(string UserName, string Password);
    public record RegisterDto(
        string Address,
        string Email,
        DateTime BirthDate,
        string UserName,
        string Password);

    public record RegisterResultDto(bool IsSuccesfull, string? Errors);
    public record LoginResultDto(bool IsSuccesfull, string? Errors, string? Token);

}
