using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class Main : MonoBehaviour
{
    [SerializeField]
    TMP_Text coin;
    [SerializeField]
    TMP_Text time;
    ulong lastPlayedTime;
    public void FirstGame()
    {
        SceneManager.LoadScene(1);
        lastPlayedTime = ulong.Parse(PlayerPrefs.GetString("LastTime"));
    }
    public void SecondGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Update()
    {
        coin.text = "total coin : " + PlayerPrefs.GetInt("coins").ToString();
        ulong diffrence = (ulong)DateTime.Now.Ticks - ulong.Parse(PlayerPrefs.GetString("LastTime"));
        ulong ms = diffrence / TimeSpan.TicksPerHour;
        print(ms);
        int temp = Convert.ToInt32(ms);
        time.text ="Time Left : "+ (24-temp) .ToString();

    }
}
