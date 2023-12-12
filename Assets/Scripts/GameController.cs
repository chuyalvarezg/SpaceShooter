using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float hScore, totalScore;
    private bool spawning, gameover, updateInitials,powerup;
    private int life = 3;
    private int totalTime, roll;

    [SerializeField]
    private GameObject normalAsteroid;
    [SerializeField]
    private GameObject fastAsteroid;
    [SerializeField]
    private GameObject goldAsteroid;

    [SerializeField]
    private GameObject powerObject;

    [SerializeField]
    private Transform asteroidSpawnPoint;
    [SerializeField]
    private Text lifeDisplay;
    [SerializeField]
    private Text scoreDisplay;
    [SerializeField]
    private Text gameoverText;
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private Text timerDisplay;
    [SerializeField]
    private InputField initialsText;
    [SerializeField]
    private Button mainMenu;
    [SerializeField]
    private GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        lifeDisplay.text = "Life: " + life + "/3";
        PlayerPrefs.SetFloat("Score", 0);
        mainMenu.gameObject.SetActive(false);
        initialsText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            timerDisplay.text = Time.timeSinceLevelLoad.ToString("F0");
            if (!spawning)
            {
                StartCoroutine(spawnAsteroids());
            }

            if (!powerup)
            {
                StartCoroutine(spawnPowerUp());
            }

            scoreDisplay.text = "Score: " + PlayerPrefs.GetFloat("Score");
        }
    }

    public void loseLife()
    {
        life--;
        lifeDisplay.text = "Life: " + life + "/3";
        if (life <= 0)
        {
            endGame();
        }
    }


    private void endGame()
    {
        totalTime =(int) Time.timeSinceLevelLoad;
        ship.SetActive(false);
        gameover = true;
        gameoverText.text = "YOU LOSE!";
        
        //revisa highscore existentes
        hScore = PlayerPrefs.GetFloat("Highscore",0);
        totalScore = PlayerPrefs.GetFloat("Score");
        if (totalScore > hScore)
        {
            PlayerPrefs.SetFloat("Highscore",totalScore);
            PlayerPrefs.SetInt("time", totalTime);
            highscoreText.text = "New Highscore! " + totalScore;
            initialsText.gameObject.SetActive(true);
            updateInitials = true;
        }
        else
        {
            highscoreText.text = "Highscore: "+hScore;
        }

        mainMenu.gameObject.SetActive(true);
        
    }

    public void returnToMainMenu()
    {
        if (updateInitials)
        {
            PlayerPrefs.SetString("initials", initialsText.text);
        }
       
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator spawnAsteroids()
    {
        spawning = true;
        Instantiate(asteroidType(), new Vector3(asteroidSpawnPoint.position.x, asteroidSpawnPoint.position.y , (Random.Range(-40f,40f)/10f) + asteroidSpawnPoint.position.z) ,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        spawning = false;
    }

    private GameObject asteroidType()
    {
        roll = Random.Range(0, 6);
        if (roll == 4)
        {
            return fastAsteroid;
        }
        else if (roll == 5)
        {
            return goldAsteroid;
        }else
        {
            return normalAsteroid;
        }
    }

    IEnumerator spawnPowerUp()
    {
        powerup = true;
        yield return new WaitForSeconds(25f);
        Instantiate(powerObject, new Vector3(asteroidSpawnPoint.position.x, asteroidSpawnPoint.position.y, (Random.Range(-40f, 40f) / 10f) + asteroidSpawnPoint.position.z), Quaternion.identity);
        powerup = false;
    }
}
