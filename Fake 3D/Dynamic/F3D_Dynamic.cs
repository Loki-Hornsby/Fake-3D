using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the class where the base script is handled
// configurable variable are meant to be added on top of this abstract class

namespace F3D {
    public enum F3D_DynamicStages {
        Idle,
        Change,
        None
    }

    public abstract class F3D_Dynamic<ItemScript> : MonoBehaviour 
            where ItemScript: MonoBehaviour
        {

        [System.NonSerialized] public List<F3D_DynamicItem<ItemScript>> items;
        [System.NonSerialized] public Unitilities.Counter NextID;

        [Header("Dynamic")]
        public bool AffectThis;
        public bool AffectChildren;

        private void CreateNewItem(GameObject obj){
            // Initialize a new Dynamic Item and add it to the list
            F3D_DynamicItem<ItemScript> item = new F3D_DynamicItem<ItemScript>().Add(obj);
            items.Add(item);
        }

        public virtual void Start(){
            items = new List<F3D_DynamicItem<ItemScript>>();

            NextID = new Unitilities.Counter();
            NextID.Set(0);

            if (AffectThis){
                CreateNewItem(this.gameObject);
            }

            if (AffectChildren){
                foreach (Transform child in this.transform){
                    CreateNewItem(child.gameObject);
                }
            }

            if (!AffectChildren && !AffectThis) Debug.LogError("You need to set atleast one condition for dynamic options to true");
        }
    }
}