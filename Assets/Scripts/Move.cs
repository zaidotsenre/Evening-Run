using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.back * GameManager.instance.Velocity * Time.deltaTime);
    }   
}
