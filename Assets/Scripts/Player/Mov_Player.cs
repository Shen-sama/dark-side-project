using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class Mov_Player : MonoBehaviour
{
    public float animSpeed = 1.5f;

    public float speed = 7.0f;

    public float rotateSpeed = 2.0f;

    //public float jumpPower = 3.0f; 
    private Rigidbody2D rb;
    private Vector3 velocity;
    private Animator anim;
    bool IsWalking;
    bool rightLooking;

    public float[] Limits;
    public bool StopMoviment = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = animSpeed;
        rb = GetComponent<Rigidbody2D>();
        if (transform.eulerAngles.y >= 270)
            rightLooking = false;
        else
            rightLooking = true;
    }
    void Update()
    {
        if (!StopMoviment)
            Move();
        else
            anim.SetBool("Walking", false);
        //exitScene();

        //JUMP
        //rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        //anim.SetBool("Jump", true);	
    }
    void Move()
    {
        float v = Input.GetAxis("Horizontal");

        if (v == 0)
            IsWalking = false;
        else if (v < 0)
        {
            anim.SetFloat("Speed", -v);
            girar(true);
            IsWalking = true;
        }
        else if (v > 0)
        {
            anim.SetFloat("Speed", v);
            girar(false);
            IsWalking = true;
        }


        velocity = new Vector3(v * speed, 0, 0);

        if (transform.localPosition.x < Limits[0])
        {
            transform.localPosition = new Vector3(Limits[0], transform.position.y, transform.position.z);
        }
        if (transform.localPosition.x > Limits[1])
        {
            transform.localPosition = new Vector3(Limits[1], transform.position.y, transform.position.z);
        }
        anim.SetBool("Walking", IsWalking);
        transform.localPosition += velocity * Time.fixedDeltaTime;
    }
    void girar(bool Right)
    {    
        if (!Right)
            if (transform.eulerAngles.y >= 270 && !rightLooking)
            {
                rightLooking = true;
                transform.eulerAngles = new Vector3(0, 90f, 0);

            }
        if (Right)
            if (transform.eulerAngles.y >= 90 && rightLooking)
            {
                rightLooking = false;
                transform.eulerAngles = new Vector3(0, 270f, 0);

            }
    }

    public void exitScene()
   {      
        float degreesPerSecond = 150.0F;
        transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime);

        bool go = true;
        if (go)
        {
            Invoke("proxScene", 0.8F);
            go = false;
        }

    }   
    void proxScene()
    {
        SceneManager.LoadScene("Paullo");
    }

}

