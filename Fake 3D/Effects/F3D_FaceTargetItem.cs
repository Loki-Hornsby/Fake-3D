/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using F3D;

namespace F3D {
    public class F3D_FaceTargetItem : F3D_DynamicItemBehaviour<F3D_FaceTarget> {
        public Vector3 TargetPosition;
        bool rotate;

        void Start(){
            base.Start();

            rotate = true;
        }

        void Update(){
            // Target
            if (Player.Instance != null){
                switch (Script.Target){
                    case Targets.Player:
                        TargetPosition = Player.Instance.transform.position;
                        break;
                    case Targets.LastGroundedPosition:
                        TargetPosition = Movement.Instance.LastGroundedPos;
                        break;
                }
            }

            // Rotation
            if (rotate){
                if (Script.Rotation == RotationType._3D){
                    transform.rotation = Quaternion.LookRotation(transform.position - TargetPosition);
                } else {
                    transform.right = ((Script.Inverse) ? -1 : 1) * (TargetPosition - transform.position);
                }
            }

            // Near Target behaviour
            float dist = Vector3.Distance(this.transform.position, TargetPosition);

            if (dist < Script.NearbyRadius && TargetPosition != Vector3.zero){
                switch (Script.NearbyBehaviour){
                    case NearbyBehaviors.None:
                        break;
                    case NearbyBehaviors.Disable:
                        this.enabled = false;
                        break;
                    case NearbyBehaviors.Idle:
                        rotate = false;
                        break;
                }
            } else {
                rotate = true;
            }
        }
    }
}