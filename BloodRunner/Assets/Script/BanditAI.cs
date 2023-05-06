using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAI : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    [SerializeField] private Animator anim;
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    private enum State {idle, Walk}
    private State state = State.Walk;

    void Start()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("state", (int)state);//set animation state
        state = State.Walk;
       
        transform.Translate(Vector2.right*speed*Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down, distance);
        
        if(groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
