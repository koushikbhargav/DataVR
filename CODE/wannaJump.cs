using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wannaJump : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Selected", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 100) > 50)
        {
            anim.SetBool("Selected", true);
        }
        else
        {
            anim.SetBool("Selected", false);
        }
    }
}
