using UnityEngine;

namespace GoblinsTreasure.Scripts.UI {

    public class LoadingScreen : MonoBehaviour {

        private void Awake() => Hide();

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }

}