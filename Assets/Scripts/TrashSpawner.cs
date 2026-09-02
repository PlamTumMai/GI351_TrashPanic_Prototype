using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab;
    public float spawnInterval = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnTrash), 1f, spawnInterval);
    }

    void SpawnTrash()
    {
        Instantiate(trashPrefab, transform.position, Quaternion.identity);
    }
}
