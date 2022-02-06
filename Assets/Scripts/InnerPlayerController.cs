using UnityEngine;

public class InnerPlayerController : MonoBehaviour
{


    public int maxHealth = 10;
    private int currentHealth;

    public int maxBullets = 6;
    private int currentBullets;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("Amount of time in seconds before each shot")]
    private float fireRate = 0.4f;

    private float timeSinceLastShot;

    public Animator animator;
    public Animator birdAnimator;

    private void Start()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        currentHealth = maxHealth;
        currentBullets = maxBullets;
        timeSinceLastShot = 0f;
        animator.Play("gun_start_ui");
    }

    private void Update()
    {
        if (!GameManager.Instance.IsTabbedOut)
        {
            CheckForShooting();
            CheckForReload();
        }
        if (GameManager.Instance.Birdiness > 1)
        {
            animator = birdAnimator;
        }

        timeSinceLastShot += Time.deltaTime;
    }

    private void CheckForShooting()
    {
        //if button is pressed and time
        if (timeSinceLastShot > fireRate && Input.GetMouseButton(0))
        {
            if (currentBullets >= 1)
            {
                Shoot();
            } else
            {
                Debug.Log("Out of Ammo");
            }
            
        }
    }

    private void CheckForReload()
    {
        //if button is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading...");
            //refill bullets
            currentBullets = maxBullets;
            //play animation 
            animator.Play("gun_reload_ui");
            //set time to shoot to be extended
            timeSinceLastShot = -2f;
        }
    }

    //shooting controls
    void Shoot()
    {
        Debug.Log("Shooting a bullet...");
        //spawn bullet in at a certain postion (cam facing position)
        GameObject spawned = Instantiate(bullet);

        //set bullet movement direction (diretion of cam facing)
        if (spawned.TryGetComponent(out BulletController controller))
        {
           // controller.direction = 
        }
            
        //remove bullet
        currentBullets--;
        timeSinceLastShot = 0f;
        //play animation
        animator.Play("gun_shoot_ui");
    }


    //interaction controls (press e when next to and looking at interactable object)
    //collect

    
}
