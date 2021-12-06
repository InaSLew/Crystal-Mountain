using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private int numberOfCrystal;
    private float xOffset;
    private SpriteRenderer  _renderer;
    
    void Awake()
    {
        for (var i = 0; i < numberOfCrystal; i++)
        {
            var crystal = Instantiate(crystalPrefab, startPosition + new Vector3(xOffset * i, 0, 0), Quaternion.identity);
            if (i != 0) continue;
            _renderer = crystal.GetComponent<SpriteRenderer>();
            xOffset = _renderer.size.x;
        }
    }

    
}
