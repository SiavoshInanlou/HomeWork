using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace BallGame
{
    public class UnityAddsManager : Singleton<UnityAddsManager>, IUnityAdsListener
    {
        string gameId = "4167779";
        bool testMode = false;
        string myPlacementId = "rewardedVideo";
       
        public GameObject Loading;
        // Start is called before the first frame update
        void Start()
        {
            
            Advertisement.Initialize(gameId, testMode);
            Advertisement.AddListener(this);
           
            Loading.SetActive(false);
        }
       
        // Update is called once per frame
       
        public void ShowVideoAdds()
        {
            Advertisement.Show(myPlacementId);
        }
        public void OnUnityAdsReady(string placementId)
        {
            if (Loading != null)
            Loading.SetActive(false);
        }
       
        public void OnUnityAdsDidError(string message)
        {
            
            Loading.SetActive(false);
           
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if(showResult==ShowResult.Finished)
            {
                GameManager.Instance.SetBackAllHealth();
                GameManager.Instance.SetTime();
            }
            else if(showResult == ShowResult.Skipped)
            {
               
            }
            else if(showResult == ShowResult.Failed)
            {
                
            }
            
        }
    }
}
