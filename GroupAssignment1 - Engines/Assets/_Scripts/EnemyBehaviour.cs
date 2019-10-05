using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
        public enum enemyState
    {
        Move,
        Attack

    }

    
    public enemyState enemyMode;
    void Start()
    {
        enemyMode = enemyState.Move;
    }

    // Update is called once per frame
    void Update(enemyState enemyMode, Collider other)
    {
        //Destroy if falls off
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        switch (enemyMode)
        {
            case enemyState.Move:
            //If not close to player, move in a direction
            if(other.CompareTag("Player"))
                if(Vector3.Distance(other.gameObject.transform.position, transform.position) < 10)  
                {
                    enemyMode = enemyState.Attack;
                    Debug.Log("AttackState");
                } 
                //transform.LookAt(other.gameObject.transform);

                break;
            case enemyState.Attack:
            //If close to player, seek player
            if(other.CompareTag("Player"))
                if(Vector3.Distance(other.gameObject.transform.position, transform.position) > 10)  
                {
                    enemyMode = enemyState.Move;
                } 
                transform.LookAt(other.gameObject.transform);
                transform.position += transform.forward * speed * Time.deltaTime;

                break;

        }
    }
}
