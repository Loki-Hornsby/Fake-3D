/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public class F3D_RarefactionItem : F3D_DynamicItemBehaviour<F3D_Rarefaction> {
        int id;
        bool move;

        float distToNext;

        F3D_Stack Stack;
        Vector3 StartPosition;
        Unitilities.Counter delta;
        
        public override void Start(){
            base.Start();

            // Set and then update id
            id = Script.NextID.t<int>();
            Script.NextID.Update(1);

            // time
            delta = new Unitilities.Counter();

            // stack script
            Stack = GetComponentInParent<F3D_Stack>();

            // original position
            StartPosition = this.transform.position;
        }

        public void Update(){
            if (id == 0 || move){
                delta.Update(Time.deltaTime / Script.delay);
            }
            
            if (id > 0) {
                distToNext = Vector3.Distance(
                    Script.items[id - 1].obj.transform.position, 
                    transform.position
                );
            } else {
                distToNext = 0f;
            }

            if (Script.Behaviour == RarefactionBehaviour.bump && distToNext <= Stack.gap / 4f
                || move || Script.Behaviour == RarefactionBehaviour.spring){

                move = true;

                transform.Translate(
                    (
                        -Vector3.forward * Script.magnitude * (
                            (
                                (
                                    Mathf.Sin(
                                        delta.t<float>() 
                                    ) * ((Script.Behaviour == RarefactionBehaviour.spring) ? (id + 1) : 1f)
                                ) / (Script.damping)
                            )
                        )
                    )
                );
            }
        }
    }
}