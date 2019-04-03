using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{

    float timer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
        anim.Play("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
