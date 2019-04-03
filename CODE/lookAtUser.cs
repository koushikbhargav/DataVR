using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtUser : MonoBehaviour
{
    public GameObject user;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(user.transform);
    }
}
