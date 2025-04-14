using UnityEngine;
using System.Collections;
public class SardineSpawnScript : MonoBehaviour
{
    public GameObject Sardine;
    private int spawnValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnSardine());
    }

    // Update is called once per frame
    static int heightRand(int low = -8, int high = 8)
    {
        return Random.Range(low, high);
    }
    IEnumerator SpawnSardine()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 5);
            if (spawnValue == 1)
            {
                GameObject newSardine = Instantiate(Sardine, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
                float scale = 0.4f + Random.Range(0, 10) * 0.02f;
                newSardine.transform.localScale = new Vector3(scale, scale, 1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
