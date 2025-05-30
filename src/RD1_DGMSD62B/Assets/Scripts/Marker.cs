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

    [SerializeField]
    private Transform initialPosition;
    [SerializeField]
    private Transform finalPosition;
    [SerializeField]
    private float noteDuration = 2;

    Vector3 offset = new Vector3(1.1405757f * 1.8f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debugging starts here
        if (string.IsNullOrEmpty(notation))
        {
            return;
        }

        if(Time.time > nextPlayTime)
        {
            nextPlayTime = Time.time + speed;
            if(currentNote < notation.Length && notation.Substring(currentNote, 1) != "0")
            {
                CreateNote();
            }
            currentNote++;
            if(currentNote >= notation.Length)
            {
                currentNote = 0;
            }
        }
    }

    void CreateNote()
    {
        GameObject tempGO = Instantiate(prefab, transform);
        InterpolationMove interpMove = tempGO.GetComponent<InterpolationMove>();
        if (interpMove != null)
        {
            interpMove.initial = initialPosition.position;
            interpMove.destination = finalPosition.position;
            interpMove.time = noteDuration;
            interpMove.destroyAtEnd = true;
            interpMove.actuallyRun = true;
        }

        // tempGO.transform.position = initialPosition.position;  //The x and y coordinates should be left as they are unless changes to the backboard and marker positions are made.  The z coordinate is the z position of the marker at the end + 5 (-2.8 + 5)
        // //Note for point system: The cube takes 2 seconds to drop from the top of the board to the bottom of the board
        // iTween.MoveTo(tempGO, iTween.Hash("position", finalPosition.position, "time", noteDuration, "easeType", iTween.EaseType.linear, "isLocal", true));
        // Destroy(tempGO, noteDuration);

        /*
        GameObject tempGO = Instantiate(prefab, transform);
        tempGO.transform.localPosition = new Vector3(0.55f, 2.75f, 2.2f);  //The x and y coordinates should be left as they are unless changes to the backboard and marker positions are made.  The z coordinate is the z position of the marker at the end + 5 (-2.8 + 5)
        //Note for point system: The cube takes 2 seconds to drop from the top of the board to the bottom of the board
        iTween.MoveTo(tempGO, iTween.Hash("position", new Vector3(0.5549f, 2.75f, -2.8f), "time", 2f, "easeType", iTween.EaseType.linear, "isLocal", true));
        Destroy(tempGO, 2f);
         */
    }
}
