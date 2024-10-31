using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject bat; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBat", 1f);
    }

    void SpawnBat()
    {
        Vector3 pos = new Vector3(Random.Range(0f, 20f), 1, Random.Range(0f, 20f));
        Instantiate(bat, pos, Quaternion.identity);
        Invoke("SpawnBat", 3f);
    }
}
