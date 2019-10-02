using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //var gameCamera : Camera;
    //var sceneCamera : Camera;
    public Transform PlayerTransform;
    public float MaxSpeed = 1;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public Camera sceneCamera;
    //This is the second Camera and is assigned in inspector
    public Camera gameCamera;
    void Start()
    {
        //gameCamera = transform.position - PlayerTransform.position;
        sceneCamera = Camera.main;
        //This enables Main Camera
        sceneCamera.enabled = true;
        //Use this to disable secondary Camera
        gameCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AddObject.cameraChange)
        {
            sceneCamera.enabled = false;
            gameCamera.enabled = true;
            //gameCamera = Camera.main;
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            move(x, y);

            Vector3 newPos = PlayerTransform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        }
    }
    private void move(float x, float y)
    {
        transform.position += (Vector3.forward * MaxSpeed) * y * Time.deltaTime;
        transform.position += (Vector3.right * MaxSpeed) * x * Time.deltaTime;
    }

}
