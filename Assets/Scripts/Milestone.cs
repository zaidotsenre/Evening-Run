using UnityEngine;

public class Milestone : MonoBehaviour
{
    readonly Vector3 startPosition = new Vector3(0, 1, 10);
    Transform thisTransform;

    void Start()
    {
        thisTransform = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Runner")
            thisTransform.position = startPosition;

    }
}
