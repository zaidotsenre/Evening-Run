using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    [SerializeField] GameObjectPool[] consumablePools;

    [Tooltip("The Z position of each lane where objects will be spawned.")]
    [SerializeField] float[] lanes;

    [Tooltip("Minimum distance between each spawned object.")]
    [SerializeField] float separation;

    Vector3 spawnPos;

    void Start()
    {
        spawnPos = transform.position;
        spawnPos.z += separation;
        SpawnRandom();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tomato") || other.CompareTag("Soda"))
            SpawnRandom();
    }

    void SpawnRandom ()
    {
        int poolIndex = Random.Range(0, consumablePools.Length);
        int laneIndex = Random.Range(0, lanes.Length);

        spawnPos.x = lanes[laneIndex];
        GameObject consumable = consumablePools[poolIndex].GetNext();
        consumable.transform.position = spawnPos;
    }
}
