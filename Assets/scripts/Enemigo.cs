using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Rigidbody rb;
    Transform player;

    public float speed;
    public float detectionRange;
    bool gotPlayer = false;
    public float waitTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Debug.Log(gotPlayer);

        if (!gotPlayer) MoveToPlayer();
        else
        {
            if (!isRunning) StartCoroutine(WaitABit());
        }
    }

    void MoveToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    bool isRunning = false;
    IEnumerator WaitABit()
    {
        isRunning = true;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(waitTime);
        gotPlayer = false;
        isRunning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gotPlayer)
        {
            Debug.Log("CHOCO");
            gotPlayer = true;
        }
    }
}

