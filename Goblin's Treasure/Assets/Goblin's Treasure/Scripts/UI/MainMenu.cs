using GoblinsTreasure.Scripts.Commands;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;

    private void Awake() {

        _startGameButton.onClick.AddListener(OnStartButtonPressed);
        _optionsButton.onClick.AddListener(OnOptionsButtonPressed);
        _exitButton.onClick.AddListener(OnExitButtonPressed);

        EventSystem.current.SetSelectedGameObject(_startGameButton.gameObject);
    }

    private void OnStartButtonPressed() => ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadGameSceneCommand());

    private void OnOptionsButtonPressed() {

    }

    private void OnExitButtonPressed() {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_STANDALONE
        Application.Quit();
#endif

    }

}