using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    private AudioSource source;
    public bool playOnButtonPress = false;
    public string button;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playOnButtonPress)
        {
            CheckButtonPress();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Drumstick Head")
        {
            Debug.Log("Trigger");
            source.volume = other.gameObject.GetComponent<TrackSpeed>().speed;
            ActivateSound();
        }   
    }

    private void ActivateSound()
    {
        source.Play();
    }

    void CheckButtonPress()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            ActivateSound();
        }

        switch (button)
        {
            case "A":
                if (OVRInput.GetDown(OVRInput.RawButton.A));
                break;
            default:
                break;
        }
    }
}
