﻿using System.ComponentModel;

namespace CelestialObjects.Domain
{
    public enum DiscoverySourceTypeEnum
    {
        [Description("Space Telescope")]
        SpaceTelescope = 1,
        [Description("Ground Telescopte")]
        GroundTelescope = 2,
        [Description("Other")]
        Other = 3
    }
}
