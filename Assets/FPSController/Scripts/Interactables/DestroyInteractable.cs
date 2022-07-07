using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{    
    public class DestroyInteractable : Interactable
    {
        public override void OnInteract()
        {
            base.OnInteract();

            Destroy(gameObject);
        }
    }
}
