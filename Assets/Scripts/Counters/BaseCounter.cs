using UnityEngine;

namespace Counters {
    public class BaseCounter : MonoBehaviour {
        public virtual void Interact(Player player) {
            Debug.LogError("Called BaseCounter.Interact(), shouldn't happened.");
        }
    }
}