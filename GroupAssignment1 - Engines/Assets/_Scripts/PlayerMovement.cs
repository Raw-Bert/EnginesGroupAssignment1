using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Runtime.InteropServices;

public class PlayerMovement : MonoBehaviour
{
    //const string DLL_NAME = "TestPlugin";
    //[DllImport(DLL_NAME)]    private static extern int SimpleFunction();
    //public bool playerActive = false;
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AddObject.playerActive)
        {
            Vector3 dir = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            transform.position += dir * speed;
        }

        //if (Input.GetKeyDown(KeyCode.S))        
        //{
            //Debug.Log(SimpleFunction());        
        //}
    }
}
