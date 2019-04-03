using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shifting : MonoBehaviour
{
    float startTime;
    private float journeyLength;
    public Transform startMarker;
    public float speed = 1.0F;
    public float fracJourney;
    public List<GameObject> places = new List<GameObject>();
    Transform destination;
    bool move = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            int rand = Random.Range(0, places.Count);
            destination = places[rand].transform;
            move = true;
        }
        if(move)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
            if(transform.position == destination.position)
            {
                move = false;
            }
        }
    }
}
