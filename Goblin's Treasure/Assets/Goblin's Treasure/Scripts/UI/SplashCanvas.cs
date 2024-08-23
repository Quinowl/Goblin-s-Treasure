using UnityEngine;
using TMPro;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using UnityEngine.InputSystem;
using GoblinsTreasure.Scripts.Commands;

namespace GoblinsTreasure.Scripts.UI {

    public class SplashCanvas : MonoBehaviour {

        [SerializeField] private TMP_Text _pressAnyKeyText;

        private bool _hasStarted;
        private TweenerCore<Color, Color, ColorOptions> _blinkDotween;

        private void Awake() {

            _blinkDotween = _pressAnyKeyText.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }

        private void Update() {

            _blinkDotween.Play();
        }

        private void OnAny(InputValue value) {

            if (_hasStarted) return;
            GoToMainMenu();
        }

        private async void GoToMainMenu() {

            _hasStarted = true;
            _pressAnyKeyText.enabled = false;

            await new LoadSceneCommand(Constants.SCENE_MAIN_MENU).Execute();
        }
    }

}