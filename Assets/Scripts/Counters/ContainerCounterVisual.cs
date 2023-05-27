using UnityEngine;

namespace Counters {
    public class ContainerCounterVisual : MonoBehaviour {
        private const string OpenCloseConst = "OpenClose";
        
        [SerializeField] private ContainerCounter containerCounter;
        
        private Animator _animator;
        private static readonly int OpenClose = Animator.StringToHash(OpenCloseConst);

        private void Start() {
            containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
        }
        
        private void ContainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs e) {
            _animator.SetTrigger(OpenClose);
        }
    }
}