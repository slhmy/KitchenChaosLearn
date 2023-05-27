using System;
using ScriptableObjects;
using UnityEngine;

namespace Counters {
    public class ContainerCounter : BaseCounter {
        public event EventHandler OnPlayerGrabbedObject;

        [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
        public override void Interact(Player player) {
            if (player.HasKitchenObject()) return;
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}