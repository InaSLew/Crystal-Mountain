using UnityEngine;

/// <summary>
/// Controls when player collides with other gameobjects and emits game events accordingly
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private VoidGameEvent playerIsDead;
    [SerializeField] private VoidGameEvent playerWin;

    public void OnCollideWithEnemy() => playerIsDead.Raise(new GenericVoid());

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate")) CollideWithGate();
        else if (other.CompareTag("Ground")) PlayerIsFalling();
    }

    private void CollideWithGate() => playerWin.Raise(new GenericVoid());

    private void PlayerIsFalling() => playerIsDead.Raise(new GenericVoid());
}
