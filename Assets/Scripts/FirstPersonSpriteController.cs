using UnityEngine;

public class FirstPersonSpriteController : MonoBehaviour
{
    [SerializeField]
    private Camera fpCamera;

    private void Start()
    {
        if (fpCamera == null)
        {
            fpCamera = GameManager.Instance.innerPlayerCam;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(fpCamera.transform);
    }
}