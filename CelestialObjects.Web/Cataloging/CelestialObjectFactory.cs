using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelestialObjects.Web.Cataloging
{
    public class CelestialObjectFactory : ICelestialObjectFactory
    {
        public CelestialObject BuildCelestialObject(CelestialObjectRequestDto celestialObjectInfo)
        {
            var ruleImplementations = GetRuleImplementations();
            var rulesResult = RunRulesCheck(celestialObjectInfo, ruleImplementations);

            if (rulesResult.Any())
            {
                var lowestPrecedenceRule = rulesResult.OrderBy(x => x.RulePrecedence).First();
                return InitCelestialObject(celestialObjectInfo, lowestPrecedenceRule.CelestialObjectType);
            }

            return InitCelestialObject(celestialObjectInfo, CelestialObjectTypeEnum.Undetermined);
        }
        
        private CelestialObject InitCelestialObject(CelestialObjectRequestDto celestialObjectInfo, CelestialObjectTypeEnum type)
        {
            return new CelestialObject
            {
                Name = celestialObjectInfo.Name,
                Mass = celestialObjectInfo.Mass,
                EquatorialDiameter = celestialObjectInfo.EquatorialDiameter,
                SurfaceTemperature = celestialObjectInfo.SurfaceTemperature,
                DiscoveryDate = celestialObjectInfo.DiscoveryDate,
                DiscoverySourceId = celestialObjectInfo.DiscoverySourceId,
                TypeId = (int)type                
            };
        }

        private static IEnumerable<Type> GetRuleImplementations()
        {
            Type celestialObjectRuleType = typeof(IRule);
            IEnumerable<Type> ruleImplementations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => celestialObjectRuleType.IsAssignableFrom(p) && p.IsClass);
            
            return ruleImplementations;
        }

        private IEnumerable<IRule> RunRulesCheck(CelestialObjectRequestDto celestialObjectInfo, IEnumerable<Type> ruleImplementations)
        {
            var result = new List<IRule>();
            foreach (var ruleImplementation in ruleImplementations)
            {
                var ruleInstance = (IRule)Activator.CreateInstance(ruleImplementation); ;
                var ruleIsMet = ruleInstance.RuleIsMet(celestialObjectInfo);

                if (ruleIsMet) { result.Add(ruleInstance); }
            }

            return result;
        }
    }
}
