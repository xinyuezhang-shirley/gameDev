using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Store Player Body
    /// </summary>

    public Rigidbody2D playerBody;

    public Vector2 velocity;

    public float speed = 3.0f;

    public float force = 300.0f;

    public bool onGround = false;

    public GameObject StrawberryPrefab;

    public GameObject BlueberryPrefab;

    public float strawberryCoolDown = 2.0f;

    public float blueberryCoolDown = 5.0f;

    public float nextStrawberry = 0f;

    public float nextBlueberry = 5f;

    public bool facingRight = true;

    public AudioSource audioSource1;

    public AudioClip bling;

    public AudioSource audioSource2;

    public AudioClip wawah;

    public AudioSource audioSource3;

    public AudioClip pfft;





    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Time.time >= nextStrawberry)
        {
            makeStrawberry();
            nextStrawberry = Time.time + strawberryCoolDown;
        }

        if (Time.time >= nextBlueberry)
        {
            makeBlueberry();
            nextBlueberry = Time.time + blueberryCoolDown;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                facingRight = false;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            playerBody.velocity = new Vector2(-speed, playerBody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if (facingRight==false)
            {
                facingRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            playerBody.AddForce(Vector3.up * force);
            onGround = false;
        }
    }

    private void makeStrawberry()
    {
        Vector3 strawberrySpawn = Spawner.RandomCoinPoint;
        Instantiate(StrawberryPrefab, strawberrySpawn, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground") == true)
        {
            audioSource3.PlayOneShot(pfft, 0.7F);
            onGround = true;
            
        }
        else if (collision.collider.CompareTag("helper") == true)
        {
            onGround = true;
        }
        else if (collision.collider.GetComponent<Strawberry>() == true)
        {
            audioSource1.PlayOneShot(bling, 0.7F);
        }
        else if (collision.collider.GetComponent<Blueberry>() == true)
        {
            audioSource2.PlayOneShot(wawah, 0.7F);
        }
    }

    private void makeBlueberry()
    {
        Vector3 blueBerrySpawn = Spawner.RandomCoinPoint;
        Instantiate(BlueberryPrefab, blueBerrySpawn, Quaternion.identity);
    }

    void OnBecameInvisible()
    {
        transform.position = Spawner.RandomCoinPoint;
    }



}
