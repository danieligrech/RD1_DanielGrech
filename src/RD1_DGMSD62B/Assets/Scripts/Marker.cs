using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject prefab;

    public string notation;
    public float speed;

    private float nextPlayTime;
    private int currentNote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextPlayTime)
        {
            nextPlayTime = Time.time + speed;
            if(notation.Substring(currentNote, 1) != "0")
            {
                CreateNote();
            }
            currentNote++;
        }
    }

    void CreateNote()
    {
        GameObject tempGO = Instantiate(prefab, transform);
        tempGO.transform.localPosition = new Vector3(-0.5549f, 2.75f, 2.2f);  //The x and y coordinates should be left as they are unless changes to the backboard and marker positions are made.  The z coordinate is the z position of the marker at the end + 5 (-2.8 + 5)
    }
}
