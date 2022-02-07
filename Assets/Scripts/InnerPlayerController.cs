using System.Collections;
using UnityEngine;

public class InnerPlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform startingPos;
    public int maxHealth = 10;
    private int currentHealth;
    private bool dying;

    [SerializeField]
    private float invincibilityTime = 1f;
    private float lastTimeHurt;

    public int maxBullets = 6;
    private int currentBullets;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject eggBullet;

    

    [SerializeField]
    private AudioClip gunshot;
    [SerializeField]
    private AudioClip birdshot;

    [SerializeField]
    private AudioClip gunReload;

    [SerializeField]
    private AudioClip birdReload;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    private InnerHudController hud;

    [SerializeField]
    [Tooltip("Amount of time in seconds before each shot")]
    private float fireRate = 0.4f;

    private float timeSinceLastShot;

    [SerializeField]
    private Camera playerCam;
    [SerializeField]
    private Vector3 directionLooking;

    public Animator animator;

    private void Start()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        currentHealth = maxHealth;
        currentBullets = maxBullets;
        timeSinceLastShot = 0f;
        transform.position = startingPos.position;
        transform.rotation = startingPos.rotation;
        if (GameManager.Instance.Birdiness < 1)
        {
            animator.Play("gun_start_ui");
        } else
        {
            animator.Play("bird_start_ui");
        }
        UpdateDisplay();
        dying = false;


    }

    private void Update()
    {
        if (!dying && currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        if (!GameManager.Instance.IsTabbedOut)
        {
            CheckForShooting();
            CheckForReload();
        }
       

        directionLooking = playerCam.transform.forward;

        timeSinceLastShot += Time.deltaTime;
        lastTimeHurt += Time.deltaTime;
    }

    private void CheckForShooting()
    {
        //if button is pressed and time
        if (timeSinceLastShot > fireRate && Input.GetMouseButton(0))
        {
            if (currentBullets >= 1)
            {
                Shoot();
                UpdateDisplay();
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
            UpdateDisplay();
            //play animation 
            if (GameManager.Instance.Birdiness < 1)
            {
                animator.Play("gun_reload_ui");
                audioSource.PlayOneShot(gunReload);
            }
            else
            {
                animator.Play("bird_reload_ui");
                audioSource.PlayOneShot(birdReload);
            }
            //set time to shoot to be extended
            timeSinceLastShot = -2f;
        }
    }

    //shooting controls
    void Shoot()
    {
        Debug.Log("Shooting a bullet...");
        //spawn bullet in at a certain postion (cam facing position)
        GameObject currentBullet;

        //play animation
        if (GameManager.Instance.Birdiness < 1)
        {
            currentBullet = bullet;
            animator.Play("gun_shoot_ui");
            audioSource.PlayOneShot(gunshot);
        }
        else
        {
            currentBullet = eggBullet;
            animator.Play("bird_shoot_ui");
            audioSource.PlayOneShot(birdshot);
        }
        GameObject spawned = Instantiate(currentBullet, transform.position + directionLooking * 1.75f, Quaternion.identity);
        //set bullet movement direction (diretion of cam facing)
        if (spawned.TryGetComponent(out BulletController controller))
        {
            controller.direction = directionLooking;
        }
            
        //remove bullet
        currentBullets--;
        timeSinceLastShot = 0f;



    }


    //interaction controls (press e when next to and looking at interactable object)
    //collect

    private void UpdateDisplay()
    {
        hud.updateAmmo(currentBullets, maxBullets);
        hud.updateHealth(currentHealth, maxHealth);
    }

     IEnumerator Die()
     {
        dying = true;
        hud.DisplayDeathcard();
        

        yield return new WaitForSeconds(3f);
        ResetPlayer();
        hud.HideDeathcard();
     }

    private void OnTriggerStay(Collider other)
    {
        //if not in invincibility and colliding with enemy
        if (lastTimeHurt > invincibilityTime && other.TryGetComponent(out EnemyAI enemy))
        {
            if (!enemy.isDying)
            {
                TakeDamage(2);
            }

        }
    }

    public void TakeDamage(int damage)
    {
        //take dmg from enemy
        currentHealth -= damage;
        UpdateDisplay();
        lastTimeHurt = 0f;
        //play sound effect
    }
}
