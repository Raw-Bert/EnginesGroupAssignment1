using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMakerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!playerActive)
        //{
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.position += dir * speed;
        //}
    }
}
