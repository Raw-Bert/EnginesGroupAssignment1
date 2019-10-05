using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool enemySpawn = false;
    public GameObject enemy;
    int enemies = 0;
    float timer = 5;
    IList<GameObject> enemyCopy = new List<GameObject>();
    IList<float> enemyCount = new List<float>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(!(AddObject.cameraChange))
        {
            timer = Time.time;
        }
        if (Time.time > timer)
        {
            timer += 5;
            enemySpawn = true;
        }
        //Spawn Enemy every 5 seconds
        if (enemySpawn)
        {
        
            enemyCopy.Add(Instantiate(enemy));
            enemyCount.Add(0);
            enemyCopy[enemyCopy.Count - 1].transform.position = transform.position;
            enemies += 1;
            enemySpawn = false;
            Debug.Log(enemies);
        }
    }
}
