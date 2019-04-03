using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class scalingByFactor : MonoBehaviour
{
    [SerializeField]
    // Get .csv file with all the data.
    StreamReader reader;
    int scene;

    public List<GameObject> neighborhood = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Pollution")
        {
            print("Pollution");
            reader = new StreamReader("C:\\Users\\jmduo\\OneDrive\\Documents\\LAHacks19\\Assets\\SAMPLE1.csv");
            scene = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Real Estate")
        {
            print("Real Estate");
            reader = new StreamReader("C:\\Users\\jmduo\\OneDrive\\Documents\\LAHacks19\\Assets\\real_estate_2016 - Sheet1.csv");
            scene = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Homeless")
        {
            print("Homeless");
            reader = new StreamReader("C:\\Users\\jmduo\\OneDrive\\Documents\\LAHacks19\\Assets\\homelessness_2017_to_2018 - Sheet1.csv");
            scene = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Crime Data")
        {
            print("Crime Data");
            reader = new StreamReader("C:\\Users\\jmduo\\OneDrive\\Documents\\LAHacks19\\Assets\\Crime Rates in LA - Sheet1 (2).csv");
            scene = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Transit Usage")
        {
            print("Transit Usage");
            reader = new StreamReader("C:\\Users\\jmduo\\OneDrive\\Documents\\LAHacks19\\Assets\\transit_use_2016_to_2017 - Sheet1.csv");
            scene = 4;
        }
        // Start with scaled buildings.
        readCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Scale the buildings.
    void scaleBuilding(System.Collections.Generic.List<float> factor1, System.Collections.Generic.List<float> factor2, System.Collections.Generic.List<float> factor3, float factor1MAX, float factor2MAX, float factor3MAX)
    {
        for(int i = 0; i < neighborhood.Count; i++)
        {
            neighborhood[i].transform.localScale = new Vector3(factor1[i] / factor1MAX, factor2[i] / factor2MAX * 8, factor3[i] / factor3MAX);
            neighborhood[i].transform.GetChild(0).localScale = new Vector3(1/neighborhood[i].transform.localScale.x, 1 / neighborhood[i].transform.localScale.y, 1 / neighborhood[i].transform.localScale.z);
            neighborhood[i].transform.position += new Vector3(0, neighborhood[i].transform.localScale.y / 2, 0);
            neighborhood[i].transform.GetChild(0).position += new Vector3(0, neighborhood[i].transform.localScale.y / 2, 0);
        }
    }

    void readCSV()
    {
        // Check if there are no more filled rows.
        bool endOfFile = false;
        // Array stores values for each building.
        float[] fMAX = new float[3];
        // Lists store values of either length, width, or height for ALL buildings.
        List<float> factor1 = new List<float>();
        List<float> factor2 = new List<float>();
        List<float> factor3 = new List<float>();

        // Still on a row with data.
        while (!endOfFile)
        {
            // Read the row.
            string data_String = reader.ReadLine();
            // End reading if reached a row of no data.
            if (data_String == null)
            {
                endOfFile = true;
            }
            else
            {
                string[] dataValues = data_String.Split(',');
                float[] value = new float[3];
                for(int i = 0; i < dataValues.Length; i++)
                {
                    // Separate the row into 3 values.
                    value[i] = float.Parse(dataValues[i]);

                    switch(i)
                    {
                        case 0:
                            factor1.Add(value[i]);
                            break;
                        case 1:
                            factor2.Add(value[i]);
                            break;
                        case 2:
                            factor3.Add(value[i]);
                            break;
                    }
                    // Check if the value is the max value.
                    if(value[i] > fMAX[i])
                    {
                        fMAX[i] = value[i];
                    }
                }
            }
        }
        switch(scene)
        {
            case 0:
                scaleBuilding(factor1, factor2, factor3, fMAX[0], fMAX[1], fMAX[2]);
                break;
            case 1:
                for(int i = 0; i < factor1.Count; i++)
                {
                    factor1[i] = 1;
                }
                scaleBuilding(factor1, factor3, factor1, 1, fMAX[2], 1);
                break;
            case 2:
                scaleBuilding(factor3, factor1, factor3, fMAX[2], fMAX[0], fMAX[2]);
                break;
            case 3:
                scaleBuilding(factor1, factor2, factor3, fMAX[0], fMAX[1], fMAX[2]);
                break;
            case 4:
                scaleBuilding(factor3, factor1, factor3, fMAX[2], fMAX[0], fMAX[2]);
                break;
        }
    }
}
