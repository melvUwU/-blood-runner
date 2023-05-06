using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    //start() variables
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] private Animator anim;
    
    private Collider2D coll;

    //state
    private enum State {idle, walk, jumping, falling, hurt};
    
    private State state = State.idle;

    //inspector variables
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 70f;
    private float hurtForce = 25f;
    private bool hitdoorGeneral = false;
    private AudioSource Jump;
    public AudioClip Heal;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public GameObject textPressE;
   


    private void Start()
    {

        
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Jump = GetComponent<AudioSource>();
 

        PermanentUI.perm.healthAmount.text = PermanentUI.health.ToString();

    }
    private void Update()
    {
        if(state != State.hurt)
        {
            playerMovement();
        }
        velocityState();
        anim.SetInteger("status", (int)state);//set animation state
        if (Input.GetKeyDown(KeyCode.E) && hitdoorGeneral)
        {
            textPressE.gameObject.GetComponent<Text>().color = Color.clear;
            SceneManager.LoadScene("Scene02_general");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "general")
        {
            hitdoorGeneral = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "general")
        {
            hitdoorGeneral = true;
        }
        if (collision.tag == "blooddrop")
        {
            Destroy(collision.gameObject);
            PermanentUI.perm.blooddrop += 1;
            PermanentUI.perm.bloodCount.text = ("x") + PermanentUI.perm.blooddrop.ToString();
        }
        if (collision.tag == "coin")
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(collision.gameObject);
            PermanentUI.perm.coin += 1;
            PermanentUI.perm.coinCount.text = ("x") + PermanentUI.perm.coin.ToString();
        }
        if(collision.tag == "brand")
        {
            if (PermanentUI.health < 10)
            {
                AudioSource.PlayClipAtPoint(Heal, transform.position);
                Destroy(collision.gameObject);
                PermanentUI.health += 1;
                PermanentUI.perm.healthAmount.text = PermanentUI.health.ToString();
            }
        }
        if (collision.tag == "patient")
        {
            if (Interaction.pickedMedic.Count >= 1)
            {
                AudioSource.PlayClipAtPoint(Heal, transform.position);
                Patient.recover();
                Interaction.pickedMedic.RemoveAt(0);
                PermanentUI.perm.medic -= 1;
                PermanentUI.perm.medicAmount.text = ("x") + PermanentUI.perm.medic.ToString();
                PermanentUI.perm.patient+= 1;

            }
        }
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "enemy")
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            state = State.hurt;
            Health(); //dealls with health, updating ui, and will reset level if health is <= 0

            if (other.gameObject.transform.position.x > transform.position.x)
            {
                //enemy is to my right therefore i should be damage and move left
                rigidBody.velocity = new Vector2(rigidBody.velocity.x - hurtForce, rigidBody.velocity.y);

            }
            else
            {
                //enemy is to my left therefore i should be damage and move right
                rigidBody.velocity = new Vector2(rigidBody.velocity.x + hurtForce, rigidBody.velocity.y);
            }
        }
        if (other.gameObject.tag == "badguys")
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            state = State.hurt;
            PermanentUI.health -= 2;
            PermanentUI.perm.healthAmount.text = PermanentUI.health.ToString();

            if (PermanentUI.health <= 0)
            {
                GameOver.gameOver = true;
                PermanentUI.perm.Reset();
                SceneManager.LoadScene("GameOver");
            }

            if (other.gameObject.transform.position.x > transform.position.x)
            {
                //enemy is to my right therefore i should be damage and move left
                rigidBody.velocity = new Vector2(rigidBody.velocity.x - hurtForce, rigidBody.velocity.y);

            }
            else
            {
                //enemy is to my left therefore i should be damage and move right
                rigidBody.velocity = new Vector2(rigidBody.velocity.x + hurtForce, rigidBody.velocity.y);
            }
        }
        if (other.gameObject.tag == "city2")
            {
                SceneManager.LoadScene("Scene2_1_thecity2");
            }
        if (other.gameObject.tag == "city3")
            {
                SceneManager.LoadScene("Scene_the_city3");
            }

        if (other.gameObject.tag == "end")
        {
            Debug.Log("End");
            EndScene.endGame = true;
            SceneManager.LoadScene("End");
        }
    }

    private void Health()
    {

        PermanentUI.health -= 1;
        PermanentUI.perm.healthAmount.text = PermanentUI.health.ToString();

        if (PermanentUI.health <= 0)
        {
            GameOver.gameOver = true;
            PermanentUI.perm.Reset();
            SceneManager.LoadScene("GameOver");
        }
    }

    private void playerMovement()
    {
        //move left
        float hDirection = Input.GetAxis("Horizontal");
        if (hDirection < 0)
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(1f, 1f);


        }
        //move right
        else if (hDirection > 0)
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);

        }
        else
        {
            state = State.idle;
        }
        //jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            state = State.jumping;
        }
    }
    private void velocityState()
    {
        if (state == State.jumping)
        {
            if(rigidBody.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }
        }

        else if (state == State.hurt)
        {
            if(Mathf.Abs(rigidBody.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rigidBody.velocity.x) > 2f)
        {
            state = State.walk;
        }
        else
        {
            state = State.idle;
        }
    }

    private void JumpSound()
    {
        Jump.Play();
    }
   
}
