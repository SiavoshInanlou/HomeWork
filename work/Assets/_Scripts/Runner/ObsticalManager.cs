using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalManager : Singleton<ObsticalManager>
{
    public List<GameObject> obsticalList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        int rand = Random.Range(0, 9);
        int tempInt = -3;
        if (rand>0 &&rand<2)
        {
            tempInt = 0;
            for (int i = 0; i < 2; i++)
            {
                GameObject temp = Instantiate(obsticalList[0]);
                temp.transform.position = new Vector3(tempInt, 1, (30 + (Random.Range(1, 6))));
                tempInt += 3;
            }
        }
        if (rand > 2 && rand < 4)
        {
            tempInt = -3;
            for (int i = 0; i < 2; i++)
            {
                GameObject temp = Instantiate(obsticalList[0]);
                temp.transform.position = new Vector3(tempInt, 1, (30 + (Random.Range(1, 6))));
                tempInt += 3;
            }
        }
        if (rand > 4 && rand < 8)
        {
            tempInt = -3;
            for (int i = 0; i < 3; i++)
            {
                GameObject temp = Instantiate(obsticalList[0]);
                temp.transform.position = new Vector3(tempInt, 1, (30 + (Random.Range(1, 6))));
                tempInt += 3;
            }
        }
        else
        {
           
                GameObject temp = Instantiate(obsticalList[0]);
                temp.transform.position = new Vector3(0, 1, (30 + (Random.Range(1, 6))));
               
            
        }
        
        

    }
    
}
