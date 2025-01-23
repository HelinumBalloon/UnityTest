using UnityEngine;

public class HerringMove : MonoBehaviour
{
    private int behaviourType;
    private int scaleFactor;

    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        behaviourType = Random.Range(0, 5);
    }
    void FixedUpdate()
    {
        scaleFactor = Random.Range(5, 10);
        if (behaviourType < 3)
        {
            transform.position += (Vector3.left * scaleFactor) * Time.fixedDeltaTime;
        }
        else if (behaviourType == 3)
        {
            float offset = scaleFactor * Mathf.Sin(Time.time * scaleFactor);
            transform.position += (Vector3.left * scaleFactor + Vector3.up * offset) * Time.fixedDeltaTime;
        }
        else if (behaviourType == 4)
        {
            
        }
        else
        {
            
        }
    }
}
