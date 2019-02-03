using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject goodPrefab;
    public GameObject badPrefab;

    private Vector3 goodPosition;
    private Vector3 badPosition;

    void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            goodPosition = new Vector3(Random.Range(-14, 13), 1, Random.Range(-13, 13));
            badPosition = new Vector3(Random.Range(-14, 13), 1, Random.Range(-13, 13));

            Instantiate(goodPrefab, goodPosition, Quaternion.identity);
            Instantiate(badPrefab, badPosition, Quaternion.identity);
        }
    }
}
