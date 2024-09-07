using GoblinsTreasure.Scripts.Gameplay;
using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerPush : MonoBehaviour {

        [SerializeField] private AreaChecker _pushChecker;
        private Player _player;
        private Crate _currentCrate;

        public void Configure(Player player) {
            _player = player;
        }

        private void Update() {

            if (_pushChecker.IsOverlapping && _pushChecker.GetComponentInCollider(out Crate crate)) TryToUpdateCurrentCrate(crate);
            else TryToUpdateCurrentCrate(null);

            if (_currentCrate != null) _currentCrate.Push(_player.MovementDirection * _player.CurrentStats.PushForce);
        }

        private void TryToUpdateCurrentCrate(Crate nextCrate) {
            // CurrentCrate can be null
            if (_currentCrate != nextCrate) {
                if (nextCrate == null) _currentCrate.StopPush();
                _currentCrate = nextCrate;
            }
        }
    }
}