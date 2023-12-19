using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueberry : MonoBehaviour
{
    public float countDown = 2.0f;
    public bool countDownRunning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countDownRunning)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground") == true)
        {
            countDownRunning = true;
        }
        else if (collision.collider.CompareTag("helper") == true)
        {
            countDownRunning = true;
        }
        else if (collision.collider.CompareTag("Player") == true)
        {
            ScoreKeeper.ScorePoints(-1);
            Destroy(gameObject);
        }
    }
}

