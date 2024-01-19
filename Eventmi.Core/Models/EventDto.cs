using Eventmi.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Eventmi.Core.Models;

public class EventDto
{
    /// <summary>
    /// "Identifier of the event"
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the event
    /// </summary>
    [Required(ErrorMessage = UserMessageConstants.Required)]
    [Display(Name="Name of the event")]
    [StringLength(50,MinimumLength=10,ErrorMessage = UserMessageConstants.StringLength)] 
    public string Name { get; set; } = null!;

    /// <summary>
    /// Start of the event
    /// </summary>
    [Required(ErrorMessage = UserMessageConstants.Required)]
    [Display(Name = "Start of the event")]
    public DateTime Start { get; set; }

    /// <summary>
    /// End of the event
    /// </summary>
    [Required(ErrorMessage = UserMessageConstants.Required)]
    [Display(Name = "End of the event")]
    public DateTime End { get; set; }
    /// <summary>
    /// Place
    /// </summary>
    [Required(ErrorMessage = UserMessageConstants.Required)]
    [Display(Name = "Place")]
    public string StreetAddress { get; set; } = string.Empty;
    /// <summary>
    /// Town
    /// </summary>
    [Range(1,int.MaxValue, ErrorMessage = UserMessageConstants.Required)]
    [Display(Name = "Town")]
    public int TownId { get; set; }

}
