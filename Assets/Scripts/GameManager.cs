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

        if (timing < 0)
        {
            Debug.Log("MISS!");
            return;
        }

        if (timing <= 0.15f)
        {
            Debug.Log("PERFECT!");
            AddScore(100);
        }
        else if (timing <= 0.4f)
        {
            Debug.Log("GOOD!");
            AddScore(50);
        }
        else
        {
            Debug.Log("MISS!");
            AddOverload();
            return;
        }

        Destroy(catchZone.currentTrash.gameObject);
        catchZone.currentTrash = null;
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

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}