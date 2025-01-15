using UnityEngine;
using System.Collections;
public class SardineSpawnScript : MonoBehaviour
{
    public GameObject Sardine;

    private float spawnRate = 3f;
    private float minSpawnRate = 2f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnSardine();
        StartCoroutine(SpawnChange());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnSardine();
            timer = 0f;
            minSpawnRate *= 1.01f;
        }
    }
    static int heightRand(int low = -8, int high = 8)
    {
        return Random.Range(low, high);
    }
    
    void spawnSardine()
    {
        Instantiate(Sardine, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
    }

    IEnumerator SpawnChange()
    {
        yield return new WaitForSeconds(spawnRate);
        spawnRate = Random.Range(minSpawnRate, 4f);
    }
}
