/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public enum SpinStages {
        Idle,
        Change,
        None
    }

    public class F3D_Spin : F3D_Dynamic<F3D_SpinItem> {
        [Header("Times")]
        public Vector2 EffectChangeTimeRange;
        public Vector2 SpeedChangeTimeRange;
        
        [Header("Options")]
        public List<float> Speeds = new List<float>();
        public bool RandomDirectionChange;
    }
}
