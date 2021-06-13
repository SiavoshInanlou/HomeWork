using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMapTrigger : MonoBehaviour
{
    [SerializeField]
    bool isRespawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if(isRespawn)
            {
               
                ObsticalManager.Instance.Respawn();
            }
            else
            {
                FindObjectOfType<RoadManager>().SetNewRoad();
                ObsticalManager.Instance.Respawn();
            }
           
        }
    }
}
