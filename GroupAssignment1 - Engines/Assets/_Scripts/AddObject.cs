﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public KeyCode createKey;
    public KeyCode finalizeKey;
    public KeyCode selectKey;
    public KeyCode oneKey;
    public KeyCode twoKey;
    public KeyCode threeKey;
    public KeyCode fourKey;


    public KeyCode playKey;
    public GameObject platform;
    public GameObject finishPlatform;
    public GameObject spikes;

    public GameObject spawner;
    int finishPlat = 0;
    int Selection = 0;
    //bool keyPressed = false;
    //float timer = 0;
    public static bool playerActive = false;
    public static bool cameraChange = false;

    //private Vector3 add;

    IList<GameObject> platformCopy = new List<GameObject>();
    IList<float> platformCount = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playKey))
        {
             playerActive = true;
             //(gameObject.GameCamera).camera.enabled = true;
             cameraChange = true;
        }
        else
        {
            if (Input.GetKeyDown(oneKey))
            {
                Selection = 1;
                Debug.Log(Selection);
            }
            else if (Input.GetKeyDown(twoKey))
            {
                Selection = 2;
                Debug.Log(Selection);
            }
            else if (Input.GetKeyDown(threeKey))
            {
                Selection = 3;
                Debug.Log(Selection);
            }
            else if (Input.GetKeyDown(fourKey))
            {
                Selection = 4;
                Debug.Log(Selection);
            }

            if (Selection == 1)
            {
                if (Input.GetKeyDown(createKey))
                {
                    platformCopy.Add(Instantiate(platform));
                    platformCount.Add(0);

                    platformCopy[platformCopy.Count - 1].transform.position = transform.position;
                }
            }

            else if (Selection == 2)
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
                }

            }
            else if (Selection == 3)
            {
                if (Input.GetKeyDown(createKey))
                {
                    platformCopy.Add(Instantiate(spikes));
                    platformCount.Add(0);

                    platformCopy[platformCopy.Count - 1].transform.position = transform.position + new Vector3(0,0.5f,0);
                }
            }
            else if (Selection == 4)
            {
                if (Input.GetKeyDown(createKey))
                {
                    platformCopy.Add(Instantiate(spawner));
                    platformCount.Add(0);

                    platformCopy[platformCopy.Count - 1].transform.position = transform.position + new Vector3(0,0.5f,0);
                }
            }
        }


    }
}
