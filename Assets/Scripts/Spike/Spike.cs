using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private GameEvent IsCollideWithPlayer;
    [SerializeField] private BooleanValue playerIsOnGround;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;
        if (gameObject.CompareTag("TriangleSpike")) IsCollideWithPlayer.Raise();
        else if (gameObject.CompareTag("SquareSpike"))
        {
            if (IsPlayerAboveSpike()) playerIsOnGround.BoolValue = true;
            else IsCollideWithPlayer.Raise();
        }
    }

    private bool IsPlayerAboveSpike()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        return player.transform.position.y > transform.position.y;
    }
}
