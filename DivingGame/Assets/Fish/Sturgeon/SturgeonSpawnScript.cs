using UnityEngine;
using System.Collections;

public class SturgeonSpawnScript : MonoBehaviour
{
    public GameObject Sturgeon;
    private int spawnValue;
    void Start()
    {
        StartCoroutine(SpawnSturgeon());
    }
    
    static int heightRand(int low = -8, int high = 8)
    {
        return Random.Range(low, high);
    }
    
    IEnumerator SpawnSturgeon()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 20);
            if (spawnValue == 1)
            {
                Instantiate(Sturgeon, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
