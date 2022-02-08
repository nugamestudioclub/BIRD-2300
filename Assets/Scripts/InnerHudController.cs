using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerHudController : MonoBehaviour
{
    [SerializeField]
    private Text ammoDisplay;
    [SerializeField]
    private Text ammoDisplaySecondary;
    [SerializeField]
    private Text healthDisplay;
    [SerializeField]
    private Text healthDisplaySecondary;
    [SerializeField]
    private Image deathcard;
    [SerializeField]
    private float fadeInTime = 1f;
    [SerializeField]
    private float fadeOutTime = .25f;



    public void updateHealth(int current, int total)
    {
        healthDisplay.text = $"HEALTH: {current} / {total}";
        healthDisplaySecondary.text = $"HEALTH: {current} / {total}";
    }

    public void updateAmmo(int current, int total)
    {
        ammoDisplay.text = $"AMMO: {current} / {total}";
        ammoDisplaySecondary.text = $"AMMO: {current} / {total}";
    }

    public IEnumerator DisplayDeathcard() //make cooroutine
    {
        Color color = deathcard.color;
        const float FACTOR = 0.1f;

        for (int alpha = 1; alpha <= 10; ++alpha)
        {
            color.a = alpha * FACTOR;
            deathcard.color = color;

            yield return new WaitForSeconds(fadeInTime * FACTOR);
        }

        Debug.Log($"Displaying deathcard wirh color RGBA({deathcard.color.r}, " +
            $"{deathcard.color.g}, " +
            $"{deathcard.color.b}," +
            $" {deathcard.color.a})");
    }

    public IEnumerator HideDeathcard() //make cooroutine
    {
        Color color = deathcard.color;
        const float FACTOR = 0.1f;

        for (int alpha = 9; alpha >= 0; --alpha)
        {
            color.a = alpha * FACTOR;
            deathcard.color = color;

            yield return new WaitForSeconds(fadeOutTime * FACTOR);
        }

        Debug.Log($"Hiding deathcard wirh color RGBA({deathcard.color.r}, " +
            $"{deathcard.color.g}, " +
            $"{deathcard.color.b}," +
            $" {deathcard.color.a})");
    }
}
