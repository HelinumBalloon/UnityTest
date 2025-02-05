using UnityEngine;
using System.Collections;

public class TunaSpawner : MonoBehaviour
{
	public GameObject Tuna;
	private int spawnValue;
	private int spawnAdditional;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTuna());
    }

    static int heightRand(int low = -8, int high = 8)
    {
        return Random.Range(low, high);
    }

	IEnumerator SpawnTuna()
    {
        while (true)
        {
            spawnValue = Random.Range(1, 12);
            if (spawnValue == 1)
            {
                Instantiate(Tuna, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
				GameObject[] preyList = GameObject.FindGameObjectsWithTag("BasicPrey");
				if (preyList.Length > 4)
				{
					spawnAdditional = Random.Range(0, 4);
					for (int i = 0; i < spawnAdditional; i++)
					{
						Instantiate(Tuna, new Vector3(transform.position.x, heightRand(), 0), transform.rotation);
					}
				}
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
