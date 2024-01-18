using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eventmi.Infrastructure.Data.Models;
/// <summary>
/// Town of the address
/// </summary>
[Comment("Town of the address")]
public class Town
{
    public Town()
    {
        this.Addresses = new HashSet<Address>();
    }
    /// <summary>
    /// Identifier of the town
    /// </summary>
    [Comment("Identifier of the town")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name of the town
    /// </summary>
    [Comment("Name of the town")]
    [MaxLength(80)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Addresses of the town
    /// </summary>
    [Comment("Addresses of the town")]
    public virtual ICollection<Address> Addresses { get; set; } = null!;
}
