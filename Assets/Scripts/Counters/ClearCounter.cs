using UnityEngine;

namespace Counters {
    public class ClearCounter : BaseCounter {
        public override void Interact(Player player) {
            if (!HasKitchenObject()) {
                Debug.Log("Clear counter don't have kitchen object");
                if (player.HasKitchenObject()) {
                    Debug.Log("Getting kitchen object from player");
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            } else {
                if (player.HasKitchenObject()) {
                    Debug.Log("Already has on kitchenObject in player.");
                } else {
                    GetKitchenObject().SetKitchenObjectParent(player);
                }
            }
        }
    }
}
