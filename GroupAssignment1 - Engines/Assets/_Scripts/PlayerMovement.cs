using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayerMovement : MonoBehaviour
{
    const string DLL_NAME = "TestPlugin";
    [DllImport(DLL_NAME)]    private static extern int SimpleFunction();
    public bool playerActive = false;

    public float speed;

    public KeyCode jumpKey;
    public Vector3 jumpForce = new Vector3 (0.0f, 50.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(AddObject.playerActive)
        {
            //After player becomes active, can move and jump
            Vector3 dir = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            transform.position += dir * speed;
            if (Input.GetKeyDown (jumpKey)) {
            
            GetComponent<Rigidbody>().AddForce (jumpForce);
        }
        }
        if (transform.position.y < 0)
        {
            //Player respawns after falling off
            transform.position = new Vector3(0f,10.7f,0f);
        }
        

        //.dll implemeted
        if (Input.GetKeyDown(KeyCode.Z))        
        {
            Debug.Log(SimpleFunction());        
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spikes"))
            {
                //Player respawns
                transform.position = new Vector3(0f,10.7f,0f);
            }
        else if (other.gameObject.CompareTag("Finish"))
            {
                //Player Wins
            }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            //Player respawns
            transform.position = new Vector3(0f,10.7f,0f);
        }
    }
}
