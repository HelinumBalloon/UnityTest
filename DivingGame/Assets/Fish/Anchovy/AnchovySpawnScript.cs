using UnityEngine;
using System.Collections;
public class AnchovySpawnScript : MonoBehaviour
{
    public GameObject Anchovy;
    private int spawnValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnAnchovy());
    }

    // Update is called once per frame
    static int heightRand(int low = -9, int high = 7)
    {
        return Random.Range(low, high);
    }
    IEnumerator SpawnAnchovy()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 5);
            if (spawnValue == 1)
            {
                GameObject newAnchovy = Instantiate(Anchovy, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
				float scale = 0.72f + Random.Range(0, 7) * 0.01f;
                newAnchovy.transform.localScale = new Vector3(scale, scale, 1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
