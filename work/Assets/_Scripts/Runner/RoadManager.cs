using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    public GameObject[] roads;
    [SerializeField]
    List<GameObject> poolObject= new List<GameObject>();
    public Transform currentBridge;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            GameObject temp = Instantiate(roads[i]);
            temp.SetActive(false);
            poolObject.Add(temp);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetNewRoad()
    {
        GameObject temp = GetObject();
        temp.transform.position = new Vector3(currentBridge.position.x, currentBridge.position.y, currentBridge.position.z + currentBridge.localScale.x);
        temp.SetActive(true);
        currentBridge = temp.transform;
    }
    GameObject GetObject()
    {
        List<GameObject> tempList= new List<GameObject>();
        for (int i = 0; i < poolObject.Count; i++)
        {
            if(!poolObject[i].activeInHierarchy)
            {
                tempList.Add(poolObject[i]);
            }
        }
        return (tempList[Random.Range(0, tempList.Count - 1)]);
    }
}
