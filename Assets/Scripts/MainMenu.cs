using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Text topScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        topScoreDisplay.text = PlayerPrefs.GetString("initials", "0") + " - " + PlayerPrefs.GetFloat("Highscore", 0) + " - " + PlayerPrefs.GetInt("time", 0)+"s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadTouchControls()
    {
        SceneManager.LoadScene("TapControlGame");
    }

    public void loadGyroControls()
    {
        SceneManager.LoadScene("GyroControlGame");
    }
}
