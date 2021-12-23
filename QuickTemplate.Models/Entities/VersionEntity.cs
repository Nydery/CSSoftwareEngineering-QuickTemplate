namespace QuickTemplate.Models.Entities
{
    public abstract class VersionEntity : IdentityEntity
    {
        public byte[] RowVersion { get; set; }
    }
}
