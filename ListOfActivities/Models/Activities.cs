using System.ComponentModel.DataAnnotations;
namespace ListOfActivities
{
	public class Activities
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter the name of the event.")]
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Organizer { get; set; }
		[ValidDate(ErrorMessage = "Please enter the date of the upcoming event.")]
		public DateTime EventTime { get; set; } 
		public string? EventVenue { get; set; }
	}
}