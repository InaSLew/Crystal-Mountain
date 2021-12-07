// using System.Collections.Generic;
// using System.Linq;
// using Random = UnityEngine.Random;
// using UnityEngine;
//
// public class VerticalCrystalManager : MonoBehaviour
// {
//     [SerializeField] private GameObject crystalPrefab;
//     [SerializeField] private IntValue numberOfGroundCrystal;
//     [SerializeField] private IntValue numberOfVerticalCrystal;
//
//     private Queue<GameObject> crystalQueue;
//     private Vector3 startPosition;
//     private CrystalManager crystalManager;
//
//     private void Awake()
//     {
//         crystalManager = GetComponent<CrystalManager>();
//         crystalQueue = new Queue<GameObject>(numberOfVerticalCrystal.Int);
//         var existingCrystal = crystalManager.crystalQueue.ToList()[Random.Range(0,numberOfGroundCrystal.Int - 1)];
//         for (var i = 0; i < numberOfVerticalCrystal.Int; i++)
//         {
//             var crystal = Instantiate(crystalPrefab);
//             crystal.transform.localPosition = existingCrystal.transform.localPosition + new Vector3(0, existingCrystal.transform.localScale.y, 0);
//             existingCrystal = crystalManager.crystalQueue.ToList()[Random.Range(0,numberOfGroundCrystal.Int - 1)];
//         }
//     }
// }
