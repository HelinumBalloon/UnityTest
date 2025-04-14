using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HookFrameCycler : MonoBehaviour
{
    public Sprite[] hookFrames; //go under hook frame and load element 0-> idle 1->charge 2-> shoot
    private SpriteRenderer spriteRenderer;

    private int currentState = 0; 
    private float stateStartTime;

    private List<string> actionLog = new List<string>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetState(0); // start at idle hook
    }

    void Update()
    {
        if (currentState == 0 && Input.GetKeyDown(KeyCode.Space)) // press space to change to charge mode ( replace with fist detected = True in pose detector)
        {
            SetState(1);
        }

        if (currentState == 1 && Input.GetKeyDown(KeyCode.S))// press 's' to shoot (open palm using pose detector)
        {
            SetState(2);
            Invoke("ReturnToIdle", 1f); // return to idle after hook after 1 second
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveToCSV();
        }
    }

    void SetState(int state)
    {
        currentState = state;
        float timeNow = Time.time;

        if (state == 0) // idle hook, had to scale, and shift to get pivot in the right place, will differ depending on size of background so helin, dan and roger**
        {
            actionLog.Add($"Idle,{timeNow:F2}");
            spriteRenderer.sprite = hookFrames[0];
            transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            transform.localPosition = new Vector3(-4f, 0f, 0f);
        }
        else if (state == 1) // charging hook, same logic applies
        {
            actionLog.Add($"Charge,{timeNow:F2}");
            spriteRenderer.sprite = hookFrames[1];
            transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            transform.localPosition = new Vector3(-4f, 0f, 0f);
        }
        else if (state == 2) // shooting hook, same logic apaplies 
        {
            actionLog.Add($"Shoot,{timeNow:F2}");
            spriteRenderer.sprite = hookFrames[2];
            transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        stateStartTime = timeNow;
    }
    void ReturnToIdle()
    {
        SetState(0);
    }

    void SaveToCSV()
    {
        string filePath = Application.dataPath + "/hook_action_log.csv";
        File.WriteAllLines(filePath, actionLog);
        Debug.Log("Log saved to: " + filePath);
    }
}
