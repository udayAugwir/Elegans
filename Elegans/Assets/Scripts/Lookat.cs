using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = transform.position - cam.transform.position;
        Quaternion lookrotation = Quaternion.Euler(distance.x, distance.y, distance.z);
        transform.rotation = lookrotation;
    }
}
