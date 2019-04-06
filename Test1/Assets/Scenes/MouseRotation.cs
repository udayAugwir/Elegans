using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Rotx = Input.GetAxis("Mouse X");
        float RotY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(-RotY * 8 * Time.deltaTime, Rotx * 8 * Time.deltaTime, 0));
    }
}
