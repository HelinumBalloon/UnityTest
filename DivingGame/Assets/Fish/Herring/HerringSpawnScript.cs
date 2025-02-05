using UnityEngine;
using System.Collections;
public class HerringSpawnScript : MonoBehaviour
{
    public GameObject Herring;
    private int spawnValue;
    private int groupSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnHerring());
    }

    // Update is called once per frame
    static int heightRand(int low = -6, int high = 6)
    {
        return Random.Range(low, high);
    }

    IEnumerator SpawnHerring()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 10);
            if (spawnValue == 1)
            {
                groupSize = Random.Range(2, 8);
                for (int i = 0; i < groupSize; i++)
                {
                    Instantiate(Herring, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
                    yield return new WaitForSeconds(0.5f);
                }
                yield return new WaitForSeconds(5f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
        
}
