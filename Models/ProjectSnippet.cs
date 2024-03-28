namespace website.Models
{
	public class ProjectSnippet
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public List<string>? SkillTags { get; set; }

		// How to put an Icon in here?
	}
}
