using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private List<GameObject> healthObj = new List<GameObject>();
    [SerializeField]
    private Button playBtt;
    [SerializeField]
    private Button restartBtt;
    [SerializeField]
    private Button MainBtt;
    [SerializeField]
    private GameObject losePanel;
    public GameObject loseGame;
    bool canUse;
    ulong lastPlayedTime;
    private int count;
    void Start()
    {
       
        playBtt.onClick.AddListener(RemoveHealth);
        restartBtt.onClick.AddListener(RestartLevel);
        MainBtt.onClick.AddListener(Main);
        count = 0;
        
        losePanel.SetActive(false);
        loseGame.SetActive(false);
        lastPlayedTime = ulong.Parse(PlayerPrefs.GetString("LastTime"));
    }
    public void Update()
    {
        ulong diffrence = (ulong)DateTime.Now.Ticks - lastPlayedTime;
        ulong ms = diffrence / TimeSpan.TicksPerDay;
        if(ms>2)
        {
            canUse = true;
        }
        else
        {
            canUse=false;
        }
        print(ms.ToString());
    }
    //On clicked remove one Hearth if no Hearth Left Show Add menue OR End Game
    private void RemoveHealth()
    {
        if (count < healthObj.Count)
        {
            healthObj[count].SetActive(false);
            count++;
        }
        else
        {
           
            if(canUse)
            {
                losePanel.SetActive(true);
                
                canUse = false;
            }
            else
            {
                loseGame.SetActive(true);
            }
            
        }
    }
    //Give All Health Back
    public void SetBackAllHealth()
    {
        
        losePanel.SetActive(false);
        count = 0;
        if (healthObj.Count > 0)
        {

            for (int i = 0; i < healthObj.Count; i++)
            {
                healthObj[i].SetActive(true);
            }
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
    void Main()
    {
        SceneManager.LoadScene(0);
    }
    //set Last TIme Player Watch Add
    public void SetTime()
    {
        PlayerPrefs.SetString("LastTime", DateTime.Now.Ticks.ToString());
        lastPlayedTime = ulong.Parse(PlayerPrefs.GetString("LastTime"));
    }
}
