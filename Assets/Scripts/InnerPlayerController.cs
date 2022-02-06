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
    private float fireRate = 0.2f;

    private float timeSinceLastShot;

    private void Start()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        currentHealth = maxHealth;
        currentBullets = maxBullets;
        timeSinceLastShot = 0f;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsTabbedOut)
        {
            CheckForShooting();
            CheckForReload();
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

            //set time to shoot to be extended
            timeSinceLastShot = -2f;
        }
    }

    //shooting controls
    void Shoot()
    {
        Debug.Log("Shooting a bullet...");
        //spawn bullet in at a certain postion (cam facing position)

        //set bullet movement direction (diretion of cam facing)

        //remove bullet
        currentBullets--;
        timeSinceLastShot = 0f;
        //play animation
    }


    //interaction controls (press e when next to and looking at interactable object)
    //collect

    
}
