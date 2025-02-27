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
        }
    }
}
