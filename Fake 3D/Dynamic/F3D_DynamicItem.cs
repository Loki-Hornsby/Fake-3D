/// <summary>
/// Copyright 2022, Loki Alexander Button Hornsby (Loki Hornsby), All rights reserved.
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a class for dynamic items
// An instance of this class is created for every child of F3D_Dynamic.cs and stored in a list within the aforementioned script

namespace F3D {
    public class F3D_DynamicItem<ItemScript> 
            where ItemScript: MonoBehaviour
        {

        public GameObject obj;

        public F3D_DynamicItem<ItemScript> Add(GameObject o){
            // Add Component
            obj = o;
            obj.AddComponent<ItemScript>();

            return this;
        }
    }
}