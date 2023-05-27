using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class KitchenObject : MonoBehaviour {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public static void SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent) {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab,
            kitchenObjectParent.GetKitchenObjectFollowTransform(), true);
        kitchenObjectTransform.localPosition = Vector3.zero;
    }
}