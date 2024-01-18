using Eventmi.Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventmi.Infrastructure.Data.Models;

/// <summary>
/// Event
/// </summary>
[Comment("Event")]
public class Event : IDeletable
{
    /// <summary>
    /// "Identifier of the event"
    /// </summary>
    [Comment("Identifier of the event")] 
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name of the event
    /// </summary>
    [Comment("Name of the event")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Start of the event
    /// </summary>
    [Comment("Start of the event")]
    public DateTime Start { get; set; }

    /// <summary>
    /// End of the event
    /// </summary>
    [Comment("End of the event")]
    public DateTime End { get; set; }

    /// <summary>
    /// Status of the event
    /// </summary>
    [Comment("Status of the event")]
    [Required]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Date deleted
    /// </summary>
    [Comment("Date deleted")]
    public DateTime? DeletedOn { get; set; }

    /// <summary>
    /// Identifier of the place
    /// </summary>
    [Comment("Identifier of the place")]
    public int PlaceId { get; set; }

    /// <summary>
    /// Place of the event
    /// </summary>
    [Comment("Place of the event")]
    [ForeignKey(nameof(PlaceId))]
    public virtual Address Place { get; set; } = null!;

    
}
