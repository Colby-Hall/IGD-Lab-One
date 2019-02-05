using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnController : MonoBehaviour
{
    public GameObject goodPrefab;
    public GameObject badPrefab;
    public Text cubeText;
    public int desiredCubes;


    private Vector3 goodPosition;
    private Vector3 badPosition;
    private float radius;

    private void Start()
    {
        if (desiredCubes > 70)
        {
            desiredCubes = 70;
        }

        SetCubeNumber();

        int numCubes = 0;
        for (; numCubes < desiredCubes; numCubes++)
        {
            goodPosition = new Vector3(Random.Range(-13.5f, 13.5f), 1, Random.Range(-13.5f, 13.5f));
            badPosition = new Vector3(Random.Range(-13.5f, 13.5f), 1, Random.Range(-13.5f, 13.5f));

            if (CheckCollisions(goodPosition, badPosition))
            {
                numCubes--;
            }
            else
            {
                SpawnCubes(goodPosition, badPosition);
            }
        }
    }

    private void SetCubeNumber()
    {
        cubeText.text = (2 * desiredCubes).ToString();
    }

    private void SpawnCubes(Vector3 goodPos, Vector3 badPos)
    {
        Instantiate(goodPrefab, goodPos, Quaternion.identity);
        Instantiate(badPrefab, badPos, Quaternion.identity);
    }

    private bool CheckCollisions(Vector3 goodPot, Vector3 badPot)
    {
        radius = 1.25f;
        Collider[] goodCollisions = Physics.OverlapSphere(goodPot, radius);
        Collider[] badCollisions = Physics.OverlapSphere(badPot, radius);

        foreach (Collider cubeColl in goodCollisions)
        {
            if (cubeColl.tag == "Good Pickup" || cubeColl.tag == "Bad Pickup" || cubeColl.tag == "Player")
            {
                return true;
            }
        }

        foreach (Collider cubeColl in badCollisions)
        {
            if (cubeColl.tag == "Good Pickup" || cubeColl.tag == "Bad Pickup" || cubeColl.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }
}


