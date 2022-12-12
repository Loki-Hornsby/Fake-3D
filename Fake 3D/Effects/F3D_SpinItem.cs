/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public class F3D_SpinItem : F3D_DynamicItemBehaviour<F3D_Spin> {
        Unitilities.Counter delta;

        F3D_DynamicStages Stage;

        public float x;

        [System.NonSerialized] public float SelectedSpeed;
        [System.NonSerialized] public float Speed;

        [System.NonSerialized] public float SelectedEffectChangeTime;
        [System.NonSerialized] public float SelectedSpeedChangeTime;

        float TargetDirection;
        float CurrentDirection;
        float AppliedDirection;
        
        public override void Start(){
            base.Start();

            delta = new Unitilities.Counter();

            RefreshRandoms();

            Speed = 0f;

            Stage = F3D_DynamicStages.Change;
        }

        void RefreshRandoms(){
            SelectedSpeed = Script.Speeds[Random.Range(0, Script.Speeds.Count)];
            SelectedEffectChangeTime = Random.Range(Script.EffectChangeTimeRange.x, Script.EffectChangeTimeRange.y + 1f);
            SelectedSpeedChangeTime = Random.Range(Script.SpeedChangeTimeRange.x, Script.SpeedChangeTimeRange.y + 1f);

            if (Script.RandomDirectionChange){
                TargetDirection = (Random.value > .5) ? -1 : 1;
            }
        }

        IEnumerator TriggerSpeedChange(){
            yield return new WaitForSeconds(SelectedEffectChangeTime);

            delta.Set(0f);

            RefreshRandoms();

            Stage = F3D_DynamicStages.Change;
        }

        public void Update(){
            x = ((AppliedDirection - 1f) * Speed);

            switch (Stage){
                case F3D_DynamicStages.Change:
                    delta.Update(Time.deltaTime / SelectedSpeedChangeTime);

                    Speed = Mathf.Lerp(Speed, SelectedSpeed, delta.t<float>());

                    if (Mathf.Abs(Speed - SelectedSpeed) < 1f){
                        StartCoroutine(TriggerSpeedChange());
                        Stage = F3D_DynamicStages.Idle;
                    }

                    break;

                default:
                    break;
            }

            /*var rotation = this.transform.rotation;
            rotation *= Quaternion.Euler(0f, 0f, Speed * Direction); // Bug: here - speed won't affect Quaternion.Euler since max is 180
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime / SelectedEffectChangeTime);*/

            CurrentDirection = AppliedDirection - 1f; 

            if (Script.RandomDirectionChange) AppliedDirection = Mathf.Lerp(
                CurrentDirection + 1f, 
                TargetDirection + 1f, 
                delta.t<float>()
            );

            transform.Rotate(
                Vector3.forward, 

                //(Speed * ((Script.RandomDirectionChange) ? (CurrentDirection - 1f) : 1f)) * Time.deltaTime 
                ((AppliedDirection - 1f) * Speed)
            );
        }
    }
}
