using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public enum RarefactionBehaviour {
        spring,
        bump,
        manual
    }

    [RequireComponent(typeof(F3D_Stack))]
    public class F3D_Rarefaction : F3D_Dynamic <F3D_RarefactionItem> {
        [Header("General")]
        public float delay;         // Default: 1f
        public float magnitude;     // Default: 0.2f
        public float damping;       // Default: 1000f
        public RarefactionBehaviour Behaviour;
    }
}