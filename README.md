# CelestialObjects

The solution exposes an API via GrapQL to see and add celestial objects.

**1. Setup**

  - update `appsettings.json` with your connection string
  - open terminal at CelestialObjects.Data
  - run command `dotnet ef database update --startup-project ../CelestialObjects.Web`/ 
  - run solution
  
**2. Usage**
User GraphQL intellisense to generate query

![1](https://user-images.githubusercontent.com/11473343/123823114-9141bb00-d905-11eb-9760-5464b37b460f.jpg)

Available operations with examples:
 - GET: 
 
 -celestialObjects
 `{
  celestialObjects {
    name
    mass
    discoverySource {
      name
      stateOwner
    }
  }
}`

 -discoverySources
` {
  discoverySources {
    name
    establishmentDate
    stateOwner
  }
}`

 -celestialObjectTypes
 `{
  celestialObjectTypes {
    name
    id
  }
}`

 -celestialObject
` {
  celestialObject(name: "Kepler-37b") {
    name
    mass
  }
}`

-celestialObjectsByType
`{
  celestialObjectsByType(type: "Star"){
    name
    mass
  }
}`

-celestialObjectsByDiscoveryCountry
`	{
  celestialObjectsByDiscoveryCountry(country: "USA") {
    name
    discoverySourceId
  }
}`

 - POST: 
 -addCelestialObject
 
query:
`mutation($celestialObjectInput: celestialObjectInput!) {
  addCelestialObject(celestialObjectInput: $celestialObjectInput) {
    name
    mass
    surfaceTemperature
    equatorialDiameter
    discoveryDate
    discoverySource {
      name
      stateOwner
    }
    type {
      description
    }
  }
}`

payload:
`		{
  "celestialObjectInput":
  {
    "name": "Test",
    "mass": 100.0,
    "equatorialDiameter": 10.0,
    "surfaceTemperature": 50.0,
    "discoveryDate": "2020-01-01",
    "discoverySourceId": 1
  }
}`

**3. Adding new Celestial Object Types**

Supported types: 'Planet', 'Star', 'Black Hole'
To check for a new type, for example 'Pulsar', a new `PulsarRule` must be added to `CelestialObjects.Web.Cataloging/Rule` and reflection will take care of the rest.
