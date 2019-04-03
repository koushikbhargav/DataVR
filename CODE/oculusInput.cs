using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oculusInput : MonoBehaviour
{
    [SerializeField]
    // public GameObject yearBox;
    int year;
    public GameObject map, parent, startBox;
    public GameObject contact;
    public Transform child = null;
    public bool touching;
    float rotationSpeed;
    int grade; // Switch between changing modes, years, or

    // Start is called before the first frame update
    void Start()
    {
        startBox.SetActive(true);
        rotationSpeed = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
        if ((OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Q)) && touching)
        {
            if (child == null)
            {
                child = contact.transform.GetChild(0).GetChild(1);
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
                child = contact.transform.GetChild(0).GetChild(1);
                child.gameObject.SetActive(true);
            }
            print(child.name);

            // child.GetComponent<Text>().text = "";
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            int y = SceneManager.GetActiveScene().buildIndex;

            if(y + 1 > 4)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(y + 1);
            }
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        touching = true;
        contact = other.gameObject;
        print(touching);
    }

    private void OnTriggerExit(Collider other)
    {
        touching = false;
        contact = null;
    }
}