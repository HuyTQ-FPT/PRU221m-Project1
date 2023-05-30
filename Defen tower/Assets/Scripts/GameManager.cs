using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManagerInstance;
    public static GameManager Instance
    {
        get
        {
            if (gameManagerInstance == null)
                gameManagerInstance = FindObjectOfType<GameManager>();

            return gameManagerInstance;
        }
    }

    public const int MaxLives = 5;
    public int InitialMoney;

    public int Level;
    public GameObject VictoryText;
    public GameObject GameOverText;

    public static int Lives;
    private int money;

    private int remainingEnemies;

    // Use this for initialization
    void Start ()
    {
        money = InitialMoney;


        remainingEnemies = GetComponent<EnemySpawner>().Waves.Sum(w => w.Amount);
    }

    public void EnemyEscaped(GameObject enemy)
    {
        Lives--;

        if (Lives <= 0)
        {
            GameOver();
        }

        remainingEnemies--;
        if(remainingEnemies == 0) Victory();
    }

    public void Victory()
    {
        VictoryText.SetActive(true);
        Invoke("NextLevel", 5.0f);
    }
    
    public void GameOver()
    {
        GameOverText.SetActive(true);
        Invoke("BackToMainMenu", 5.0f);
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu_screen");
    }
}
