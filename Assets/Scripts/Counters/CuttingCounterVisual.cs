using UnityEngine;

namespace Counters {
    public class CuttingCounterVisual : MonoBehaviour {
        private const string CutConst = "Cut";

        [SerializeField] private CuttingCounter cuttingCounter;

        private Animator _animator;
        private static readonly int Cut = Animator.StringToHash(CutConst);

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            cuttingCounter.OnCut += CuttingCounter_OnCut;
        }

        private void CuttingCounter_OnCut(object sender, System.EventArgs e) {
            _animator.SetTrigger(Cut);
        }

    }
}