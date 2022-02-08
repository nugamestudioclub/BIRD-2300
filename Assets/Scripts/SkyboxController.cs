using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxController : MonoBehaviour
{
    [SerializeField]
    private Volume normalBox;
    [SerializeField]
    private Volume birdBox;

    // Start is called before the first frame update
    void Awake()
    {
        normalBox.enabled = true;
        birdBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Birdiness > 0)
        {
            normalBox.enabled = false;
            birdBox.enabled = true;
        }
    }
}
