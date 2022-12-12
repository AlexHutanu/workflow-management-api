namespace WebAPI.Dtos.BoardDtos
{
    public class BoardGetDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Owner { get; set; }

        public string? Description { get; set; }

        public int NoOfTickets { get; set; }
    }
}

