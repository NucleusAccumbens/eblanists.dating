namespace Domain.Entities
{
    public class PhotoAlbum : BaseAuditableEntity
    {
        public IList<Photo>? FacePhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? ChestPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? ArmsPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? NavelPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? PubisPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? ButtocksPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? AnusPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? GenitalsPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? KneesPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? FeetPhotos { get; private set; } = new List<Photo>();
        public IList<Photo>? BackPhotos { get; private set; } = new List<Photo>();

        public Guid? DatingAppUserId { get; set; }
        public DatingAppUser? DatingAppUser { get; set; }
    }
}
