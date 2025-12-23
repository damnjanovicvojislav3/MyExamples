namespace ActorsRestService.Models
    {
    public partial class Actor
    {
        public long ActorId { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? CountryCode { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }

}