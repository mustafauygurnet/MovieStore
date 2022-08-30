namespace Core.Entities.Concrete;

public class UserOperationClaim
{
    public int UserOperationClaimId { get; set; }
    public int OperationClaimId { get; set; }
    public int UserId { get; set; }
}