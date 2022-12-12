using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public class F3D_RotationClamp : F3D_Dynamic <F3D_RotationClampItem>{
        [Header("General")]
        [Range(0, 180)] public float MaxX;
        [Range(-180, 0)] public float MinX;
        public bool InverseX;
        [Space(10)]
        [Range(0, 180)] public float MaxY;
        [Range(-180, 0)] public float MinY;
        public bool InverseY;
        [Space(10)]
        [Range(0, 180)] public float MaxZ;
        [Range(-180, 0)] public float MinZ;
        public bool InverseZ;
        [Space(10)]
        public bool IgnoreZClamp;
        public float ZTransformControl;
    }
}