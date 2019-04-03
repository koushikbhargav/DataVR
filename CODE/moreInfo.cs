using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreInfo : MonoBehaviour
{

    public oculusInput inputs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        inputs.touching = true;
        inputs.contact = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        inputs.touching = false;
        inputs.contact = null;
    }
}