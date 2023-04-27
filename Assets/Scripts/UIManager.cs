using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private float score = 0;
    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text deathScoreText;
    [SerializeField]
    private GameObject gameOverPanel;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ShowHeartsUI(player.GetComponent<PlayerController>().ShowHealth());
        ShowScoreUI(0);
    }    

    public void ShowHeartsUI(int currHealth)
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currHealth)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    public void ShowScoreUI(int currScore)
    {
        scoreText.text = ("Score: " + currScore);
        deathScoreText.text = ("Score: " + currScore);
    }

    public void RestartButtonClick()
    {
        int tmpScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(tmpScene);  
    }

    public void GoToStartButtonClick()
    {        
        SceneManager.LoadScene(0);
    }

    public void ShowDeathPanel()
    {
        scoreText.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
    }
}
