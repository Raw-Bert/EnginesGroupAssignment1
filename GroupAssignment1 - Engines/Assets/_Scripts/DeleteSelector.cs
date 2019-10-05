using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deletes the object placer cube.
public class DeleteSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AddObject.cameraChange)
        {
            Destroy(gameObject);
        }
    }
}
