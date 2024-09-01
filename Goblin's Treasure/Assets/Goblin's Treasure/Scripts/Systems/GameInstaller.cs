using GoblinsTreasure.Scripts.Events;
using GoblinsTreasure.Scripts.GameStates;
using UnityEngine;

namespace GoblinsTreasure.Scripts.Systems {

    public class GameInstaller : MonoBehaviour {

        [SerializeField] private GameStateController _gameStateController;
        [SerializeField] private EventQueue _eventQueue;
        [SerializeField] private GameDataSO _gameData;

        private void Awake() {

            ServiceLocator.Instance.RegisterService(_gameStateController);
            ServiceLocator.Instance.RegisterService(_eventQueue);

            _gameStateController.Init(_gameData);
        }

        private void OnDestroy() {

            ServiceLocator.Instance.UnregisterService<GameStateController>();
            ServiceLocator.Instance.UnregisterService<EventQueue>();
        }

    }
}