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
                GameObject newFF = Instantiate(FlyingFish, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
                float scale = 0.77f + Random.Range(0, 7) * 0.01f;
                newFF.transform.localScale = new Vector3(scale, scale, 1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
