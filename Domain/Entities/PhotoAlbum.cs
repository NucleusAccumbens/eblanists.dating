namespace Domain.Entities
{
    public class PhotoAlbum : BaseAuditableEntity
    {
        public IList<Photo>? Photos { get; private set; } = new List<Photo>();

        public Guid? DatingAppUserId { get; set; }
        public DatingAppUser? DatingAppUser { get; set; }
    }
}
