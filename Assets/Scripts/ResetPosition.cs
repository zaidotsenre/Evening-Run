using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [Tooltip("Determines the distance for a street reset. If it's 2, the street will reset after half of its length has been ran.")]
    [SerializeField] int resetDivisor;

    Transform thisTransform;
    BoxCollider thisCollider;
    float resetLength;

    void Start()
    {
        thisTransform = transform;
        thisCollider = GetComponent<BoxCollider>();
        resetLength = thisCollider.size.z / resetDivisor;
    }

    void Update()
    {
        if (thisTransform.position.z <= (0 - resetLength))
        {
            Vector3 newPosition = new Vector3(thisTransform.position.x, thisTransform.position.y, 0);
            thisTransform.position = newPosition;
        }
    }
}
