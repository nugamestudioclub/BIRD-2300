using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerHudController : MonoBehaviour
{
    [SerializeField]
    private Text ammoDisplay;
    [SerializeField]
    private Text healthDisplay;
    [SerializeField]
    private Image deathcard;

    

    public void updateHealth(int current, int total)
    {
        healthDisplay.text = $"HEALTH: {current} / {total}";
    }

    public void updateAmmo(int current, int total)
    {
        ammoDisplay.text = $"AMMO: {current} / {total}";
    }

    public void DisplayDeathcard()
    {
        deathcard.color = new Color(deathcard.color.r, deathcard.color.g, deathcard.color.b, 1);
    }

    public void HideDeathcard()
    {
        deathcard.color = new Color(deathcard.color.r, deathcard.color.g, deathcard.color.b, 0);
    }
}
