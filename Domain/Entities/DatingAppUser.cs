namespace Domain.Entities;

public class DatingAppUser : BaseAuditableEntity
{
    public Roles Role { get; set; }
    public bool? IsVegan { get; set; }
    public bool? IsNoncredist { get; set; }
    public bool? IsChildfree { get; set; }
    public bool? IsPansexual { get; set; }
    public bool? IsCosmopolitan { get; set; }
    public bool? IsBdsmLover { get; set; }
    public bool? IsMakeupUser { get; set; }
    public bool? IsHeelsUser { get; set; }
    public bool? IsTattooed { get; set; }
    public bool? IsExistLover { get; set; }
    public bool? ShaveLegs { get; set; }
    public bool? ShaveHead { get; set; }
    public bool? HaveSacred { get; set; }
    public string? OtherInfo { get; set; }

    public PhotoAlbum? PhotoAlbum { get; set; }
}

