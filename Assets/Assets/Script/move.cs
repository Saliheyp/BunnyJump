using System;
using UnityEngine;
using UnityEditor;
using Unity.Mathematics;

public class move : MonoBehaviour
{
    #region Variable
        SoundManager soundManagerSc;
        public CarrotCoinSpawn[] ccSpawn;
        public Animator BunnyAnim;
        private bool hasMoved;
        public DeathFinishPanel dfp;
        public float scoreBunny = 0;
        public Rigidbody2D rb;
        public bool boat = false;
        public bool isDead = false;
        public float jumpSpeed = 1f;
        private Vector3 rollDir;
        private Vector3 moveDir;
        private State state;
        float moveX = 0f;
        float moveY = 0f;
        private float touchStartY;
        private float touchStartX;
    #endregion

    private enum State
    {
        Idle,
        Jumping,
    }
    
    private void Awake()
    {
        state = State.Idle;
    }
    private void Start()
    {
        soundManagerSc = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

    }

    private void Update()
    {
        scoreBunny = rb.transform.position.y + 9f;
        if (!isDead)
        {
        switch(state)
        {
        case State.Idle:
        moveX = 0f;
        moveY = 0f;
        BunnyAnim.SetFloat("moveX",moveX);
        BunnyAnim.SetFloat("moveY",moveY);
           if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                        
                    if (touch.phase == TouchPhase.Began)
                    {
                        touchStartY = touch.position.y;
                        touchStartX = touch.position.x;
                        hasMoved = false;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        float touchEndX = touch.position.x;
                        float deltaX = touchEndX - touchStartX;
                        float touchEndY = touch.position.y;
                        float deltaY = touchEndY - touchStartY;
                        soundManagerSc.Jump();
                        if (!hasMoved)
                        {
                            if (deltaY > 0 && math.abs(deltaY) > math.abs(deltaX) && state == State.Idle )
                            {
                                Forward();
                                hasMoved = true;
                            }
                        
                            else if (deltaY < 0 && math.abs(deltaY) > math.abs(deltaX))
                            {
                                Back();
                                hasMoved = true;
                            }
                        
                            else if (deltaX > 0 && math.abs(deltaX) > math.abs(deltaY))
                            {
                                Right();
                                hasMoved = true;
                            }
                        
                            else if (deltaX < 0 && math.abs(deltaX) > math.abs(deltaY))
                            {
                                Left();
                                hasMoved = true;
                            }
                        }
                    }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            moveX = 0f;
                            moveY = 0f;
                            BunnyAnim.SetFloat("moveX", moveX);
                            BunnyAnim.SetFloat("moveY", moveY);
                            state = State.Idle;
                        }
                }
        break;
        
        case State.Jumping:
            float jumpSpeedDropMultiplier = 10f;
            jumpSpeed -= jumpSpeed * jumpSpeedDropMultiplier*Time.deltaTime;

            float jumpSpeedMinimum = 1.25f;
            if (jumpSpeed < jumpSpeedMinimum)
            {
                state = State.Idle;
                rb.velocity=moveDir;

            }
        break;
        }
        }
    }
    private void FixedUpdate()
    {
        switch(state)
        {
            case State.Idle:
            rb.velocity=moveDir;
            break;
            case State.Jumping:
            rb.velocity = rollDir * jumpSpeed;
            break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Boat"))
        {
            boat = true;
        }
        if (collision.gameObject.CompareTag("BigWay"))
        {
            float newYPosition = dfp.bigWay1.transform.position.y + 20f;
            dfp.bigWay2.transform.position =  new Vector3(0f ,newYPosition, 0f );
            foreach (var item in ccSpawn)
            {
                item.CarrotCoinDestroy();
            }
            foreach (var item in ccSpawn)
            {
                item.CarrotCoinSpawner();
            }
        }
        if (collision.gameObject.CompareTag("BigWay1"))
        {
            float newYPosition = dfp.bigWay2.transform.position.y + 20f;
            dfp.bigWay.transform.position =  new Vector3(0f ,newYPosition, 0f );
            foreach (var item in ccSpawn)
            {
                item.CarrotCoinDestroy();
            }
            foreach (var item in ccSpawn)
            {
                item.CarrotCoinSpawner();
            }
        }if (collision.gameObject.CompareTag("BigWay2"))
        {
            float newYPosition = dfp.bigWay.transform.position.y + 20f;
            dfp.bigWay1.transform.position =  new Vector3(0f ,newYPosition, 0f );
             foreach (var item in ccSpawn)
            {
                item.CarrotCoinDestroy();
            }
            foreach (var item in ccSpawn)
            {
                item.CarrotCoinSpawner();
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Boat"))
        {
            boat = false;
        }
    }

    public void Death()
    {
        {
            if (boat != true)
            {
                dfp.ShowDeathPanel();
                isDead = true;
                Destroy(gameObject);
                BunnyAnim.SetBool("isDead",true);
            }
        }
    }
    public void Forward()
    {
        moveY = +1;
        jumpSpeed = 15f;
        state = State.Jumping;
        BunnyAnim.SetFloat("moveY",moveY);
        moveDir = new Vector3 (0,0);
        rollDir = new Vector3 (moveX,moveY);
    }
    public void Back()
    {
        moveY = -1;
        jumpSpeed = 15f;
        state = State.Jumping;
        BunnyAnim.SetFloat("moveY",moveY);
        moveDir = new Vector3 (0,0);
        rollDir = new Vector3 (moveX,moveY);
    }
    public void Right()
    {
        moveX = 1;
        jumpSpeed = 15f;
        state = State.Jumping;
        BunnyAnim.SetFloat("moveX",moveX);
        moveDir = new Vector3 (0,0);
        rollDir = new Vector3 (moveX,moveY);
    }
    public void Left()
    {
        moveX = -1;
        jumpSpeed = 15f;
        state = State.Jumping;
        BunnyAnim.SetFloat("moveX",moveX);
        moveDir = new Vector3 (0,0);
        rollDir = new Vector3 (moveX,moveY);
    }
}
