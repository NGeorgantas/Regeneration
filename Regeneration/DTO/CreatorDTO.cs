namespace Regeneration.DTO
{
    public class CreatorDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string email { get; set; } = "";
        public int? password { get; set; }
        public List<Project>? projectList { get; set; } = null!;
    }
}
