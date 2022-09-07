using Core.Entities.Abstract;

namespace Core.Entities.Dtos;

public class OperationClaimOfUserDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}