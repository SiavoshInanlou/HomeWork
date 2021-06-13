using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    public float speed;
    Transform player;
    [SerializeField]
    List<GameObject> coins = new List<GameObject>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        int rand = Random.Range(0, coins.Count  );
        for (int i = 0; i < coins[rand].transform.childCount; i++)
        {
            coins[rand].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < coins.Count; i++)
        {
            if(i!=rand)
            {
                coins[i].SetActive(false);
            }
            else
            { coins[i].SetActive(true); }
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.position)>50)
        {
            this.gameObject.SetActive(false);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
