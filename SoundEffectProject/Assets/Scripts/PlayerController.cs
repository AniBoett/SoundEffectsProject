using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody playerRb;
	private Animator playerAnim;

    public float jumpForce;

    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            //prevent the player from double jumping
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
			playerAnim.SetTrigger("Jump_trig");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    //trigger a game over when the player collides with an obstacle
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
