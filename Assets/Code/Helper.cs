using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public Rigidbody2D helperBody;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        helperBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        helperBody.rotation = 0.0f;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            helperBody.velocity = new Vector2(-speed, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            helperBody.velocity = new Vector2(speed, 0);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            helperBody.velocity = new Vector2(0, speed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            helperBody.velocity = new Vector2(0, -speed);
        }
        else
        {
            helperBody.velocity = new Vector2(0, 0);
        }
    }


    void OnBecameInvisible()
    {
        transform.position = Spawner.RandomCoinPoint;
    }
}