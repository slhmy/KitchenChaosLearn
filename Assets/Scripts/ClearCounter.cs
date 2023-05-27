using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour {
    
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform kitchenObject;
    private KitchenObject _kitchenObject;

    public void Interact() {
        Debug.Log("ClearCounter.Interact()");
        if (!HasKitchenObject()) {
            KitchenObject.SpawnKitchenObject(kitchenObject, counterTopPoint);
        }
    }
    
    private bool HasKitchenObject() {
        return _kitchenObject != null;
    }
}
