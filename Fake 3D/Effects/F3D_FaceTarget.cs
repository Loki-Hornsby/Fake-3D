/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public enum Targets {
        LastGroundedPosition,
        Player,
        ZeroPoint
    }

    public enum RotationType {
        _2D,
        _3D
    }

    public enum NearbyBehaviors {
        None,
        Disable,
        Idle
    }

    public class F3D_FaceTarget : F3D_Dynamic <F3D_FaceTargetItem> {
        [Header("General")]
        public Targets Target;
        
        [Header("Rotation")]
        public RotationType Rotation;
        public bool Inverse;

        [Header("Near Target")]
        public NearbyBehaviors NearbyBehaviour;
        public float NearbyRadius;
    }
}