using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpeed : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        lastPosition = transform.position;
    }
}
