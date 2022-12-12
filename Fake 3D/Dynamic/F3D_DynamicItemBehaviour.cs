using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a class for handling the behaviour of each child of F3D_Dynamic.cs
// This class uses [Script] to access modified variables by me (the user)

namespace F3D {
    public abstract class F3D_DynamicItemBehaviour<DynamicScript> : MonoBehaviour 
            where DynamicScript: MonoBehaviour
        {

        public DynamicScript Script;

        public virtual void Start(){
            Script = GetComponentInParent<DynamicScript>();
        }
    }
}