using UnityEngine;

namespace GoblinsTreasure.Scripts.GameStates {

    public class GameStateController : MonoBehaviour {

        private IGameState _currentState;

        public GameData GameData { get; private set; }

        public void Init(GameData gameData) => GameData = gameData;

        private void Reset() => SwitchState(new InitialState());

        private void Start() {

            _currentState = new InitialState();
            _currentState.Start();
        }

        private void Update() {

            _currentState.Update();
        }

        private void OnDestroy() => Reset();

        public void SwitchState(IGameState newGameState) {

            _currentState.Stop();
            _currentState = newGameState;
            _currentState.Start();
        }
    }
}