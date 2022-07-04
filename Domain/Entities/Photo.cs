namespace Domain.Entities
{
    public class Photo : BaseAuditableEntity
    {
        public BodyParts BodyPart { get; set; }
        public string PathToPhoto { get; set; } = string.Empty;
        public Guid PhotoAlbumId { get; set; }
    }
}
