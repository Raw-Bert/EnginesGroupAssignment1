using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    //State pattern enum
    public enum enemyState
    {
        Move,
        Attack

    }

    public Transform player;
    public enemyState enemyMode;
    void Start()
    {
        enemyMode = enemyState.Move;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy if falls off
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Player is " + DistanceThisPlayer().ToString());

        check(enemyMode);
    }
    float DistanceThisPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    void check(enemyState enemyMode)
    {
        //State Pattern switch break statement
        switch (enemyMode)
        {
            case enemyState.Move:
                //If not close to player, move in a direction
                if (DistanceThisPlayer() < 10)
                {
                    enemyMode = enemyState.Attack;
                    //Debug.Log("Player is " + DistanceThisPlayer().ToString());
                }
                //transform.LookAt(other.gameObject.transform);

                break;
            case enemyState.Attack:
                //If close to player, seek player

                if (DistanceThisPlayer() > 10)
                {
                    enemyMode = enemyState.Move;
                }
                transform.LookAt(player.gameObject.transform);
                transform.position += transform.forward * speed * Time.deltaTime;

                break;

        }
    }
}