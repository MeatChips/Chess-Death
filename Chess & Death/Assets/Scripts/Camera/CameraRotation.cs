using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 0, 180);
            Debug.Log("Rotate Right");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, 0, -180);
            Debug.Log("Rotate Left");
        }
    }
}