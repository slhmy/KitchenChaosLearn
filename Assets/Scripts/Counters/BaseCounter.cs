using UnityEngine;

namespace Counters {
    public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent {
        [SerializeField] private Transform counterTopPoint;

        private KitchenObject _kitchenObject;

        public virtual void Interact(Player player) {
            Debug.LogError("Called BaseCounter.Interact(), shouldn't happened.");
        }

        public virtual void InteractAlternate(Player player) {
            Debug.LogError("Called BaseCounter.InteractAlternate(), shouldn't happened.");
        }

        public Transform GetKitchenObjectFollowTransform() {
            return counterTopPoint;
        }
        public void SetKitchenObject(KitchenObject kitchenObject) {
            this._kitchenObject = kitchenObject;
            if (kitchenObject != null) {
                Debug.Log("Counter already has a kitchen Object");
            }
        }
        public KitchenObject GetKitchenObject() {
            return _kitchenObject;
        }
        public void ClearKitchenObject() {
            _kitchenObject = null;
        }
        public bool HasKitchenObject() {
            return _kitchenObject != null;
        }
    }
}