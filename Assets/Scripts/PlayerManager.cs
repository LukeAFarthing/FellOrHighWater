using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public Transform playerTransform;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] public HealthBarManager healthBar;
    [SerializeField] public Rigidbody fallingWall;
    [SerializeField] private Text orbText;

    // Movement Variables
    private float playerSpeed;
    private float jumpSpeed;
    private bool isJumping;
    private float zRotation;
    private Quaternion newRotation;
    private float jumpTimer;
    private float jumpTimerDelta;
    private int orbsCollected;

    // Health Variables
    public int maxHealth;
    public int currentHealth;
    private int enemyDamage;
    //private bool isHardMode;

    // Unused Variables
    //private float groundHeight;
    //private float gravity;
    //private float fallSpeed;
    //private Vector3 currentEulerAngles;
    

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 15f;
        jumpSpeed = 18f;
        isJumping = false;
        zRotation = 157f;
        jumpTimer = 1f;
        jumpTimerDelta = 0f;
        orbsCollected = 0;

        maxHealth = 10;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //isHardMode = DifficultyManager.hard;
        if(DifficultyManager.hard)
        {
            enemyDamage = 3;
        }
        else
        {
            enemyDamage = 1;
        }

        //groundHeight = 0.5f;
        //fallSpeed = 0.02f;
        //gravity = 0f;
        //currentEulerAngles = new Vector3(90, 0, 0);
        //playerTransform.position = new Vector3(0f, groundHeight, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 eulerRotation = playerTransform.rotation.eulerAngles;
        //playerTransform.rotation = Quaternion.Euler(90, 0, eulerRotation.z);

        //modifying the Vector3, based on input multiplied by speed and time
        //currentEulerAngles += new Vector3(0, 0, 0);

        //apply the change to the gameObject
        //transform.eulerAngles = currentEulerAngles;

        if(playerTransform.position.y <= -100)
        {
            GoToLoseScreen();
        }

        // Movement code
        Vector3 movementVector = Vector3.zero;
        float xMovement = 0;
        float zMovement = 0;

        if (!(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
        {
            

            // Set forward movement and rotation
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                zMovement = 0;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                zRotation = 157f;
                zMovement = playerSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                zRotation = 337f;
                zMovement = -playerSpeed;
            }

            // Set backward movement and rotation
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                xMovement = 0;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                zRotation = 247f;
                xMovement = -playerSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                zRotation = 78.5f;
                xMovement = playerSpeed;
            }

            // Set rotation during diagonal forward movement
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                zMovement = 0;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                zRotation = 202f;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                zRotation = 117.75f;
            }

            // Set rotation during diagonal backward movement
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                zMovement = 0;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                zRotation = 292f;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                zRotation = 27.75f;
            }

            jumpTimerDelta -= Time.deltaTime;
            if (jumpTimerDelta <= 0)
            {
                isJumping = false;
            }

            // Cheat Codes

            // Full Health
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Resetting health");
                currentHealth = maxHealth;
                healthBar.SetMaxHealth(maxHealth);
            }

            // Increase/Decrease Player Speed
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.X))
            {
                if(playerSpeed == 15f)
                {
                    Debug.Log("Increasing player speed");
                    playerSpeed = 25f;
                }
                else
                {
                    Debug.Log("Resetting player speed");
                    playerSpeed = 15f;
                }
            }

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Gathering all orbs");
                orbsCollected = 5;
            }

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }

        newRotation = Quaternion.Euler(90, 0, zRotation);
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, newRotation, 10f * Time.deltaTime);

        movementVector = new Vector3(xMovement, rigidBody.velocity.y, zMovement);

        if(movementVector != Vector3.zero)
        {
            rigidBody.velocity = movementVector;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }
        */

        if(SceneManager.GetActiveScene().name == "Level1" && orbsCollected == 5)
        {
            fallingWall.useGravity = true;
            orbText.enabled = false;
            orbsCollected = 100;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset jumping variable if player touches ground
        /*
        if (isJumping && collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
        */

        if (collision.gameObject.tag == "Gun")
        {
            GoToLoseScreen();
        }

        if (collision.gameObject.tag == "Bullet1")
        {
            TakeDamage(enemyDamage);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Orb")
        {
            orbsCollected++;
            orbText.text = "Orbs Collected " + orbsCollected + "/5";
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "GoToLevel1")
        {
            SceneManager.LoadScene("Level1");
        }
        
        if (collision.gameObject.name == "GoToWin")
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        var normal = collision.contacts[0].normal;
        if (collision.gameObject.tag == "Ground" && Input.GetKey(KeyCode.Space) && normal.y > 0 && isJumping == false)
        {
            //Debug.Log("Jump");
            isJumping = true;
            jumpTimerDelta = jumpTimer;
            DoJump();
        }
    }

    private void DoJump()
    {
        rigidBody.velocity += Vector3.up * jumpSpeed;
        /*
        if (isJumping == false)
        {
            isJumping = true;
            rigidBody.velocity += Vector3.up * jumpSpeed;
        }
        */
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            GoToLoseScreen();
        }
    }

    private void GoToLoseScreen()
    {
        SceneManager.LoadScene("Lose");
    }
}
