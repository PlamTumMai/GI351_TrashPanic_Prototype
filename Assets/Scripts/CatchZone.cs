using UnityEngine;

public class CatchZone : MonoBehaviour
{
    public Trash currentTrash;

    void OnTriggerEnter2D(Collider2D other)
    {
        Trash trash = other.GetComponent<Trash>();

        if (trash != null)
        {
            currentTrash = trash;
            // Debug.Log("Trash is in Catch Zone!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Trash trash = other.GetComponent<Trash>();

        if (trash != null && currentTrash == trash)
        {
            currentTrash = null;
        }
    }

    public float GetTiming()
    {
        if (currentTrash == null)
        {
            return -1f;
        }

        float distance = Mathf.Abs(
            currentTrash.transform.position.y - transform.position.y
        );

        return distance;
    }
}