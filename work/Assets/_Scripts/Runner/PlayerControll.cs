using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : Singleton<PlayerControll>
{

    public Animator anim;
    public int count;
    bool canUse;
    public Transform RayPoint;
    public LayerMask layerMask;
    public Rigidbody rig;
    public float jumpForce;
    public bool canJump;
    void Start()
    {

        count = 0;
        canUse = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(RayPoint.position, RayPoint.TransformDirection(Vector3.down), out hit, 5f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            Debug.Log("Did Hit" + hit.distance);
            anim.SetFloat("hight", hit.distance);
            if(hit.distance<0.05)
            {
                canJump = true;
                
            }
            else
            {
                canJump = false;
            }
        }
    }

    public void Left()
    {
        if (count >= 0 && canUse&& canJump)
        {
            count--;
            
            StartCoroutine(LerpPosition(new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), 0.5f));
            StartCoroutine(SideMOve(-1));
            transform.rotation = Quaternion.Euler(new Vector3(0, -330, 0));
            canUse = false;
        }
    }
    public void Right()
    {
        if (count <= 0 && canUse&&canJump)
        {
            count++;
           
            StartCoroutine(LerpPosition(new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), 0.5f));
            StartCoroutine(SideMOve(1));
            transform.rotation = Quaternion.Euler(new Vector3(0, 330, 0));
            canUse = false;
        }
    }
    public void Jump()
    {
        if (canJump)
        {
            rig.AddForce(Vector3.up * jumpForce);
          anim.SetTrigger("Jump");
            canJump = false;
           
        }

    }
    IEnumerator SideMOve(float speed)
    {
        anim.SetFloat("Speed", speed);
        yield return new WaitForSeconds(0.5f);
        
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        anim.SetFloat("Speed", 0);
        canUse = true;
    }

}
