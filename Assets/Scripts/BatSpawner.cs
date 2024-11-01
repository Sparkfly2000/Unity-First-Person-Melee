using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject bat; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BatSpawn());
    }

    void SpawnBat()
    {
        Vector3 pos = new Vector3(Random.Range(0f, 20f), 0.5f, Random.Range(0f, 20f));
        Instantiate(bat, pos, Quaternion.identity);
    }
    IEnumerator BatSpawn()
    {
        for (float delay = 5f; delay > 0.1f; delay -= 0.1f)
        {
            if (delay < 0.1f)
            {
                delay = 0.1f;
            }
            SpawnBat();
            yield return new WaitForSeconds(delay);
        }
    }
}
