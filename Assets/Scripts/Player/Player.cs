using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameEvent playerIsDead;
    [SerializeField] private GameEvent playerWin;

    public void OnCollideWithEnemy() => playerIsDead.Raise();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate")) CollideWithGate();
        else if (other.CompareTag("Ground")) PlayerIsFalling();
    }

    private void CollideWithGate() => playerWin.Raise();

    private void PlayerIsFalling() => playerIsDead.Raise();
}
