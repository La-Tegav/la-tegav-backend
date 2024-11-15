namespace la_tegav.Domain.Common;

public class AuditableEntity
{
    //public string? CreatedBy { get; set; }
    //public string? LastModifiedBy { get; set; }

    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
