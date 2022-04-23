using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardForce = 100f;
    [SerializeField] private float force = 100f;
    [SerializeField] private float jumpForce = 100f;

    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Animator animator;
    [SerializeField] bool left;
    [SerializeField] bool right;
    [SerializeField] bool down;

    //bool isJump = false;
    [SerializeField] BoxCollider collider;

  [SerializeField ]  bool isOver = false;

    AudioManager audioManager;

    [SerializeField] GameObject destroyEffect;
    //[SerializeField] GameObject lightingEffect;
    //[SerializeField] GameObject lightingSport;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        // Jump functionalities
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow ))
        //{
       
        //    animator.SetTrigger("jump");
        //    isJump  = true;
        //}
        // slde function
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            collider.center = new Vector3(collider.center.x, .1f, collider.center.z);
            collider.size = new Vector3(collider.size.x, .5f, collider.size.z);
            animator.SetTrigger("crouch");
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            down = false;
            Invoke("ResetCollider", .5f);
        }

        //left movement 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
        }  
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
        }

        //Right Movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }

        if (transform.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    void FixedUpdate()
    {
        if (!isOver && !down )
        {

            playerRb.AddForce(Vector3.forward * forwardForce * Time.deltaTime);
            if (left)
            {
                playerRb.AddForce(Vector3.left * force * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
            if (right)
            {
                playerRb.AddForce(Vector3.right * force * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
            if (down)
            {
                down = false;
            }
            //if(isJump )
            //{
            //    playerRb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse );
            //    isJump = false;
            //    Invoke("ResetTrigger", .5f);
            //}
        }
    }
    //void ResetJumpTrigger()
    //{
    //    animator.ResetTrigger ("jump"); ;
    //}
    void ResetCollider()
    {
        collider.center = new Vector3(collider.center.x, 0.6f, collider.center.z);
        collider.size = new Vector3(collider.size.x, 1.5f, collider.size.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacal"))
        {
            isOver = true;
         //   transform.position = new Vector3(transform.position.x, transform.position.y, 5);
            animator.SetBool("fall", true);
            this.enabled = false;
            Instantiate(destroyEffect,transform.position , Quaternion.identity);
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }

}
