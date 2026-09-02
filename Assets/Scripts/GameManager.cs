using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public int overload = 0;
    public int maxOverload = 5;

    public CatchZone catchZone;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckTrash();
        }
    }

    void CheckTrash()
    {
        float timing = catchZone.GetTiming();
    // ไม่มีขยะใน CatchZone = ไม่ทำอะไร
        if (timing < 0)
        {
            return;
        }

        if (timing <= 0.15f)
        {
            Debug.Log("PERFECT!");
            AddScore(100);

            Destroy(catchZone.currentTrash.gameObject);
            catchZone.currentTrash = null;
        }
        else if (timing <= 0.4f)
        {
            Debug.Log("GOOD!");
            AddScore(50);

            Destroy(catchZone.currentTrash.gameObject);
            catchZone.currentTrash = null;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void AddMiss()
    {
        Debug.Log("MISS!");
        AddOverload();
    }

    void AddOverload()
    {
        overload++;

        Debug.Log("OVERLOAD: " + overload + "/" + maxOverload);

        if (overload >= maxOverload)
        {
            GameOver();
        }
    } 

    void GameOver()
    {
        Debug.Log("GAME OVER!");
        Time.timeScale = 0;
    }
}