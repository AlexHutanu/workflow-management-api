namespace WebAPI.Models.Board
{
    public class WriteBoardModel
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid UserId { get; set; }
    }
}
