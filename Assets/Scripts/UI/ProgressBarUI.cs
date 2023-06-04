using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class ProgressBarUI : MonoBehaviour {
        [SerializeField] private GameObject hasProgressGameObject;
        [SerializeField] private Image barImage;

        private IHasProgress _hasProgress;

        private void Start() {
            _hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

            if (_hasProgress != null) _hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
            else Debug.LogError("Game Object " + hasProgressGameObject +
                                " does not have a component that implements IHasProgress!");

            barImage.fillAmount = 0f;
            Hide();
        }

        private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
            barImage.fillAmount = e.ProgressNormalized;

            if (e.ProgressNormalized == 0f || e.ProgressNormalized == 1f) Hide();
            else Show();
        }

        private void Show() {
            gameObject.SetActive(true);
        }

        private void Hide() {
            gameObject.SetActive(false);
        }
    }
}