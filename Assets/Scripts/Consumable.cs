using UnityEngine;

public class Consumable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Runner")
            gameObject.SetActive(false);
    }
}
