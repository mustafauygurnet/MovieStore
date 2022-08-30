using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class User : IEntity
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedTime { get; set; }
}