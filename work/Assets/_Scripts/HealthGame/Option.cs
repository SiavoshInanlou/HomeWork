using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Option : MonoBehaviour
{
    [SerializeField]
    Slider soundControll;
    [SerializeField]
    Toggle mute;

    AudioSource backAuido;
    
    // Start is called before the first frame update
    void Start()
    {
        backAuido = FindObjectOfType<AudioSource>();
        mute.onValueChanged.AddListener(SetMute);
        soundControll.value = 1;
        soundControll.onValueChanged.AddListener(VolumeControl);
        if(PlayerPrefs.GetInt("Sound")==0)
        {
            mute.isOn = true;
        }
        else
        {
            mute.isOn = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VolumeControl(float vol)
    {
        backAuido.volume = vol;
    }
    public void SetMute(bool set)
    {
        if(set)
        {
            backAuido.mute = true;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            backAuido.mute = false;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
}
