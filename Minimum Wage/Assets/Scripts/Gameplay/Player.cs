using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public Vector2 start = new Vector2(98, 57);
    public int lives = 2;
    public int cash;
    public LevelUI score;
    public bool shinGuardAvailable = true;
    public int shinGuard = 0;
    public static int playTime;

    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 18f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private UnityEvent barrelBuster; 
    [SerializeField] private UnityEvent ModelEmployee;
    [SerializeField] private UnityEvent OnTheClock;
    [SerializeField] private UnityEvent BigBucks;
    private AchievementManager achievementManager;

    void Start()
    {
        if (SlotController.Load)
        {

        }
        else
        {
            playTime = 0;
        }
        achievementManager = FindObjectOfType<AchievementManager>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Fire1") && shinGuardAvailable)
        {
            shinGuardAvailable = false;
            shinGuard = 2;
            score.updateShinGuard();
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Death")
        {
            if (shinGuard > 0)
            {
                //achievementManager.NotifyAchievement("BarrelBuster");
                Destroy(collision.gameObject);
                barrelBuster.Invoke();
                shinGuard--;
                score.updateShinGuard();
            } 
            else 
            {
                if (lives > 0) 
                {
                TakeLife();
                transform.position = start;
                } 
                else 
                {
                Destroy(gameObject);
                }
            } 
        } else if (collision.gameObject.tag=="Finish") {
            if (playTime <= 60) 
            {
                OnTheClock.Invoke();
                //achievementManager.NotifyAchievement("OnTheClock"); 
            }
            if (lives == 2)
            {
                ModelEmployee.Invoke();
                //achievementManager.NotifyAchievement("ModelEmployee");
            }
            
        }
    }

    public void TakeLife() {
        lives--;
        score.ChangeLives();
    }

    public void AddCash(int value)
    {
        cash += value;
        score.ChangeCash();
        if (cash >= 50)
        {
            BigBucks.Invoke();
        }
    }

    public void SavePlayer() 
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        lives = data.lives;
        cash = data.cash;
        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
        playTime = data.time;
        score.UpdateAll();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
}
