using UnityEngine;

public class InterpolationMove : MonoBehaviour
{
    public Vector3 initial;
    public Vector3 destination;
    public float time = 2.0f;
    public bool destroyAtEnd = true;
    public bool actuallyRun = false;

    private float _elapsedTime = 0.0f;

    void Start()
    {
        if (!actuallyRun) return;
        transform.position = initial;
    }

    void Update()
    {
        if (!actuallyRun) return;

        float f = _elapsedTime / time;
        transform.position = Vector3.Lerp(initial, destination, f);

        _elapsedTime += Time.deltaTime;
        if (destroyAtEnd && f > 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
