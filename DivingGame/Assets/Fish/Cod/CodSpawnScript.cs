using UnityEngine;
using System.Collections;
public class CodSpawnScript : MonoBehaviour
{
    public GameObject Cod;
    private float spawnRate = 2f;
    private float minSpawnRate = 1.5f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCod();
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
            spawnCod();
            timer = 0f;
            minSpawnRate *= 1.005f;
        }
    }
    static int heightRand(int low = -8, int high = 8)
    {
        return Random.Range(low, high);
    }
    void spawnCod()
    {
        Instantiate(Cod, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
    }
    IEnumerator SpawnChange()
    {
        yield return new WaitForSeconds(spawnRate);
        spawnRate = Random.Range(minSpawnRate, 4f);
    }
}
