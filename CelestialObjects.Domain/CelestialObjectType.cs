using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelestialObjects.Domain
{
    public class CelestialObjectType
    {
        public CelestialObjectType(CelestialObjectTypeEnum enumValue)
        {
            Id = (int)enumValue;
            Name = enumValue.ToString();
            Description = enumValue.GetEnumDescription();
        }

        protected CelestialObjectType() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public static implicit operator CelestialObjectType(CelestialObjectTypeEnum @enum) => new CelestialObjectType(@enum);

        public static implicit operator CelestialObjectTypeEnum(CelestialObjectType faculty) => (CelestialObjectTypeEnum)faculty.Id;
    }
}
