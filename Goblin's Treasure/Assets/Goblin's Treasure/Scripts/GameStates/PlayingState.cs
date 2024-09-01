using GoblinsTreasure.Scripts.Events;

namespace GoblinsTreasure.Scripts.GameStates {

    public class PlayingState : IGameState {

        private readonly GameDataSO _gameData;

        private EventQueue _eventQueue;

        public PlayingState(GameDataSO gameData) => _gameData = gameData;

        public void Start() {

            _eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
        }

        public void Stop() {
        }

        public void Update() {
        }

    }

}