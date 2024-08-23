using GoblinsTreasure.Scripts.Commands;
using GoblinsTreasure.Scripts.UI;
using UnityEngine;

namespace GoblinsTreasure.Scripts.Systems {

    public class GlobalInstaller : MonoBehaviour {

        [Header("UI")]
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ScreenFade _screenFade;

        private void Awake() {

            DontDestroyOnLoad(_loadingScreen);
            DontDestroyOnLoad(_screenFade);

            ServiceLocator.Instance.RegisterService(_loadingScreen);
            ServiceLocator.Instance.RegisterService(_screenFade);
            ServiceLocator.Instance.RegisterService(new CommandQueue());
        }
    }

}