namespace MKW.Domain.Dto.DTO.PersonDTO
{
    public class ReadPersonDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ImageURL { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AlterDate { get; set; }
        public bool Active { get; set; }
        public int GenderId { get; set; }
    }
}
