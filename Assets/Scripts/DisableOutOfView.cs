using UnityEngine;

public class DisableOutOfView : MonoBehaviour
{
    Transform thisTransform;

    void Start()
    {
        thisTransform = transform;    
    }
    void Update()
    {
        if (thisTransform.position.z < 0)
            gameObject.SetActive(false);
    }
}
