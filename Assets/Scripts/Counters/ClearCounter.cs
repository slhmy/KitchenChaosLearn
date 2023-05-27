using UnityEngine;

namespace Counters {
    public class ClearCounter : BaseCounter {
        [SerializeField] private Transform counterTopPoint;
    
        private KitchenObject _kitchenObject;
    
        public override void Interact(Player player) {
            Debug.Log("ClearCounter.Interact()");
        }
    }
}
