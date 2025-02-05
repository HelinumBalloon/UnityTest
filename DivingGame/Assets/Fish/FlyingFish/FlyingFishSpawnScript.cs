using UnityEngine;
using System.Collections;
public class FlyingFishSpawnScript : MonoBehaviour
{
    public GameObject FlyingFish;
    private int spawnValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFlyingFish());
    }

    static int heightRand(int low = 6, int high = 10)
    {
        return Random.Range(low, high);
    }
    
    IEnumerator SpawnFlyingFish()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 20);
            if (spawnValue == 1)
            {
                Instantiate(FlyingFish, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
