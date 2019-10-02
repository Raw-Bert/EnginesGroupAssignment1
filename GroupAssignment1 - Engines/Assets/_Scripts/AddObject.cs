using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public KeyCode createKey;
    public KeyCode finalizeKey;
    public KeyCode selectKey;
    public GameObject platform;
    public GameObject finishPlatform;
    int finishPlat = 0;
    int Selection = 0;
    bool keyPressed = false;
    float timer = 0;

    IList<GameObject> platformCopy = new List<GameObject>();
    IList<float> platformCount = new List<float>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(createKey))    
        //{
        //    keyPressed = true;
        //    timer = Time.time;
        //}
        //else if (Input.GetKeyUp(createKey))
        //{
        //   keyPressed = false;
        //resourceCollected = 0;
        //}
        if (Input.GetKeyDown(selectKey))
        {
            Selection += 1;
            Debug.Log(Selection);
        }
        //Picks up resource after 1 second of holding the key down (Key is public, it is et in Unity)
        //Also sends a bool to onTriggerStay
        if (Selection == 0)
        {
            if (Input.GetKeyDown(createKey))
            {
                platformCopy.Add(Instantiate(platform));
                platformCount.Add(0);

                platformCopy[platformCopy.Count - 1].transform.position = transform.position;
                //direction.Add(transform.forward);
                //platformCopy[platformCop.Count - 1].transform.position = transform.position;
            }
        }

        else if (Selection >= 1)
        {
            if (Input.GetKeyDown(createKey))
            {
                if (finishPlat < 1)
                {
                    platformCopy.Add(Instantiate(finishPlatform));
                    platformCount.Add(0);
                    platformCopy[platformCopy.Count - 1].transform.position = transform.position;
                    finishPlat += 1;
                }
                else
                    Debug.Log("Platform already placed");
                //direction.Add(transform.forward);
                //platformCopy[platformCop.Count - 1].transform.position = transform.position;
            }

        }

    }
}
