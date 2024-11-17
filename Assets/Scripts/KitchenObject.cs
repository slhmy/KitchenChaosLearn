using ScriptableObjects;
using UnityEngine;

public class KitchenObject : MonoBehaviour {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private IKitchenObjectParent _kitchenObjectParent;

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) {
        this._kitchenObjectParent?.ClearKitchenObject();
        this._kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject()) {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        Transform transform1;
        (transform1 = transform).parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform1.localPosition = Vector3.zero;
    }

    public void DestroySelf() {
        _kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static void SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent) {
        Debug.Log(kitchenObjectParent);
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
    }

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }
}