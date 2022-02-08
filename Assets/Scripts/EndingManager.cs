using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    private string key = "score";
    [SerializeField]
    private GameObject marker;
    [SerializeField]
    private Text letterGrade;

    // Start is called before the first frame update
    void Start()
    {
        string score = PlayerPrefs.GetString(key);
        //testing

        letterGrade.text = score;
        Color finalColor;
        switch (score)
        {
            case "S":
                finalColor = Color.blue;
                break;
            case "A":
            case "A+":
            case "A-":
                finalColor = Color.green;
                break;
            case "B":
            case "B+":
            case "B-":
                finalColor = new Color(102, 255, 0);
                break;
            case "C":
            case "C+":
            case "C-":
                finalColor = Color.yellow;
                break;
            case "D":
            case "D+":
            case "D-":
                finalColor = new Color(255, 89, 0);
                break;
            default:
                finalColor = Color.red;
                break;
        }
        marker.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", finalColor);
    }

   
}
