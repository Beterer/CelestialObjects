using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelestialObjects.Domain
{
    public class DiscoverySourceType
    {
        public DiscoverySourceType(DiscoverySourceTypeEnum enumValue)
        {
            Id = (int)enumValue;
            Name = enumValue.ToString();
            Description = enumValue.GetEnumDescription();
        }

        protected DiscoverySourceType() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public static implicit operator DiscoverySourceType(DiscoverySourceTypeEnum @enum) => new DiscoverySourceType(@enum);

        public static implicit operator DiscoverySourceTypeEnum(DiscoverySourceType discoverySource) => (DiscoverySourceTypeEnum)discoverySource.Id;
    }
}
