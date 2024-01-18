using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventmi.Infrastructure.Data.Models;

/// <summary>
/// Address of the event
/// </summary>
[Comment("Address of the event")]
public class Address
{
    /// <summary>
    /// Identifier of address
    /// </summary>
    [Comment("Identifier of address")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Sreet of the place
    /// </summary>
    [Comment("Sreet of the place")]
    [MaxLength(100)]
    public string StreetName { get; set; } = null!;

    /// <summary>
    /// Identifier of town
    /// </summary>
    [Comment("Identifier of town")]
    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }

    /// <summary>
    /// Town of the address
    /// </summary>
    [Comment("Town of the address")]
    public virtual Town Town { get; set; } = null!;
}
