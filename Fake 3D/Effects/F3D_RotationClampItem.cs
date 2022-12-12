using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F3D {
    public class F3D_RotationClampItem : F3D_DynamicItemBehaviour<F3D_RotationClamp> {
        float StartingZpos;

        public override void Start() {
            base.Start();

            StartingZpos = this.transform.position.z;
            this.transform.position = this.transform.position + new Vector3(0f, 0f, Script.ZTransformControl);
        }

        float GetUnwrappedAndClampedAngle(float input, float Min, float Max, bool inverse){
            return F3D_Utilities.UnwrapAngle(
                Mathf.Clamp(
                    F3D_Utilities.WrapAngle(input), 
                    ((inverse) ? -Min : Min), ((inverse) ? -Max : Max)
                )
            );
        }

        void ApplyRotationClamp(){
            Vector3 rot = new Vector3(
                GetUnwrappedAndClampedAngle(
                    this.transform.eulerAngles.x, 
                    Script.MinX, 
                    Script.MaxX, 
                    Script.InverseX
                ),

                GetUnwrappedAndClampedAngle(
                    this.transform.eulerAngles.y, 
                    Script.MinY, 
                    Script.MaxY, 
                    Script.InverseY
                ),

                (Script.IgnoreZClamp) ? 
                    this.transform.eulerAngles.z : 
                        GetUnwrappedAndClampedAngle(
                            this.transform.eulerAngles.z, 
                            Script.MinZ,
                            Script.MaxZ,
                            Script.InverseZ
                        )
            );

            this.transform.rotation = Quaternion.Euler(rot);
        }

        void LateUpdate(){
            if (StartingZpos + Script.ZTransformControl != this.transform.position.z){
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, StartingZpos + Script.ZTransformControl);
                StartingZpos = this.transform.position.z - Script.ZTransformControl;
            }

            ApplyRotationClamp();
        }
    }
}