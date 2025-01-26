using UnityEngine;
using System.Collections;
public class CodSpawnScript : MonoBehaviour
{
    public GameObject Cod;
    private int spawnValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCod());
    }
    static int heightRand(int low = -8, int high = 8)
    {
        return Random.Range(low, high);
    }
    IEnumerator SpawnCod()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 7);
            if (spawnValue == 1)
            {
                Instantiate(Cod, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    
}
