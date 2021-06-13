using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalObj : MonoBehaviour
{
    public float speed;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(6f, 14);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 50)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
       if( other.tag=="Player")
        {
            UiManager.Instance.EndGame();
        }
    }
}
