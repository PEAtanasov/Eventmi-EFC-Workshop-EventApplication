namespace Eventmi.Infrastructure.Data.Contracts;

/// <summary>
/// Entity which can be deleted
/// </summary>
public interface IDeletable
{
    /// <summary>
    /// Ithe record is active
    /// </summary>
    public bool IsActive { get; set; }
    /// <summary>
    /// Deleted on date
    /// </summary>
    public DateTime? DeletedOn { get; set; }
}
