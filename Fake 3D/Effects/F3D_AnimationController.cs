/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public class F3D_AnimationController : MonoBehaviour {
        public List<F3D_AnimationItem> AnimationItems = new List<F3D_AnimationItem>();

        public void Trigger(string animation){
            foreach (F3D_AnimationItem item in AnimationItems) {
                Animator animator = item.GetComponent<Animator>();

                animator.ResetTrigger(animation);
                animator.SetTrigger(animation);
            }
        }
    }
}
