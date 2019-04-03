using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointNorth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Point north.
        transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
    }
}
