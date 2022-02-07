using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideAudioManager : MonoBehaviour
{
    [Header("Notifications")]
    [SerializeField]
    private AudioSource notificationSource;
    [SerializeField]
    private AudioClip itemNoteNotifSound;
    [SerializeField]
    private AudioClip correctNotifSound;
    [SerializeField]
    private AudioClip incorrectNotifSound;
    [SerializeField]
    private AudioClip questionNotif;

    [Header("Sound Effects")]
    [SerializeField]
    private AudioSource soundEffectsSource;
    [SerializeField]
    private AudioClip paperSound;
    [SerializeField]
    private AudioClip computerSound1;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNotification(NotificationType type)
    {
        switch (type)
        {
            case NotificationType.NEWITEM:
                this.notificationSource.clip = this.itemNoteNotifSound;
                break;
            case NotificationType.CORRECT:
                this.notificationSource.clip = this.correctNotifSound;
                break;
            case NotificationType.INCORRECT:
                this.notificationSource.clip = this.incorrectNotifSound;
                break;
            case NotificationType.QUSTION:
                this.notificationSource.clip = this.questionNotif;
                break;

        }
        this.notificationSource.Play();

    }

    

}

public enum NotificationType {NEWITEM, CORRECT,INCORRECT,QUSTION};
