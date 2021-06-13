using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : Singleton<UiManager>
{
    [SerializeField]
    TMP_Text coinText;
    [SerializeField]
    Image fillBar;
    int coinsCollected;
    float total=100;
    float current;
    bool checkPause;
    [SerializeField]
    GameObject loseGame;
    [SerializeField]
    GameObject puseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
        fillBar.fillAmount = current / total;
        if(current==total)
        {
            current = 0;
        }
    }
    public void AddNewCoin()
    {
        coinsCollected++;
        coinText.text = "Coins : " + coinsCollected.ToString();
        PlayerPrefs.SetInt("coins", coinsCollected+PlayerPrefs.GetInt("coins"));
    }
    public void Pause()
    {
        if(!checkPause)
        {
            checkPause = true;
            Time.timeScale = 0;
            puseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale =1;
            checkPause = false;
            puseMenu.SetActive(false);
        }

        
    }
    public void EndGame()
    {
        Time.timeScale = 0.05f;
        loseGame.SetActive(true);
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void Main()
    {
        SceneManager.LoadScene(0);
    }
}
