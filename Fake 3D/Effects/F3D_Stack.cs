/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public class F3D_Stack : MonoBehaviour{
        public float gap;

        void Start(){
            Unitilities.Counter ind = new Unitilities.Counter();

            foreach (Transform child in this.transform){
                child.position = child.position + new Vector3(0f, 0f, -(ind.t<float>() * gap));
                ind.Update(1);
            }
        }
    }
}
