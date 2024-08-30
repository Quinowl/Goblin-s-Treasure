using GoblinsTreasure.Scripts.Player;

public class PlayerDamageable : Damageable {

    private Player _player;

    public void Configure(Player player) => _player = player;

    public override void SetHealth(float amount) {

        base.SetHealth(amount);
    }

    public override void TakeDamage(float damage) {
        base.TakeDamage(damage);
    }

}