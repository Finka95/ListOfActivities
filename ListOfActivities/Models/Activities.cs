using System;
namespace ListOfActivities
{
	public class Activities
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Organizer { get; set; }
		public DateTime EventTime { get; set; }
		public string? EventVenue { get; set; }
	}
}