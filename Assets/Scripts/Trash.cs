using UnityEngine;

public class Trash : MonoBehaviour
{
    public float fallSpeed = 3f;
    public float missY = -3.5f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // ตกเลยจุดรับ = MISS
        if (transform.position.y < missY)
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.AddMiss();
            }

            Destroy(gameObject);
        }
    }
}