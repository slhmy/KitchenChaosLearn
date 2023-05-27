using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour {
    public static void SpawnKitchenObject(Transform spawningKitchenObject, Transform counterTopPoint) {
        Transform kitchenObjectTransform = Instantiate(spawningKitchenObject, counterTopPoint, true);
        kitchenObjectTransform.localPosition = Vector3.zero;
    }
}
