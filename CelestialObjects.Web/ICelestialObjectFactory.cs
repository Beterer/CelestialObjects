using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;

namespace CelestialObjects.Web
{
    public interface ICelestialObjectFactory
    {
        CelestialObject BuildCelestialObject(CelestialObjectRequestDto celestialObjectInfo);
    }
}