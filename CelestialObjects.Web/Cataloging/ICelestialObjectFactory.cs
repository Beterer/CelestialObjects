using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;

namespace CelestialObjects.Web.Cataloging
{
    public interface ICelestialObjectFactory
    {
        CelestialObject BuildCelestialObject(CelestialObjectRequestDto celestialObjectInfo);
    }
}