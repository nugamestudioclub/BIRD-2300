using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutsideGameManager : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Animator camera;
    
    private bool animRunning = false;
    private bool notebookOpen = false;

    [SerializeField]
    private Button notebookNotify;
    [SerializeField]
    private string noteBookNoficiationText = "Added a new <i>Note</i> to <b>Notebook</b>";

    [SerializeField]
    private Text dialogText;
    private Button dialogTextButton;
    private string name;
    private bool isAttentive = true;

    public Image loginpage;
    public Button nameSubmit;
    public InputField nameInput;
    
    


    // Start is called before the first frame update
    void Start()
    {
        notebookNotify.onClick.AddListener(OpenNotebook);
        Text txt = notebookNotify.GetComponent<Text>();
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0f);
        name = PlayerPrefs.GetString("name");
        if (name.Length == 0)
        {
            name = "Seb";
        }
        dialogTextButton = dialogText.gameObject.GetComponent<Button>();
        dialogTextButton.onClick.AddListener(Attentive);
        this.dialogTextButton.interactable = false;
        this.nameSubmit.onClick.AddListener(SubmitName);


    }

    void SubmitName()
    {
        this.name = this.nameInput.text;
        this.loginpage.gameObject.SetActive(false);
    }
   /// <summary>
   /// Alt-tab out and pay attention.
   /// </summary>
    private void Attentive()
    {
        camera.Play("zoom out");
        
        this.isAttentive = true;
    }
    /// <summary>
    /// Alt-tab in and don't pay attention.
    /// </summary>
    private void Unattentive()
    {
        camera.Play("zoom in");
        CloseNotebook();
        this.isAttentive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.CompareTag("Notebook"))
                {
                    if (!notebookOpen)
                        OpenNotebook();
                    else
                        CloseNotebook();
                }
                // Do something with the object that was hit by the raycast.
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab)&&!animRunning)
        {
            if (this.isAttentive)
            {
                this.Unattentive();
                StartCoroutine(WaitForAnimationOver());
            }
            else
            {
                this.Attentive();
                StartCoroutine(WaitForAnimationOver());
            }
            
        }
    }

    public void OpenNotebook()
    {
        if (!animRunning)
        {
            if (!notebookOpen)
            {
                anim.Play("Show");
                notebookOpen = !notebookOpen;
                StartCoroutine(WaitForAnimationOver());
            }
            
            
        }
    }
    private void CloseNotebook()
    {

        if (!animRunning)
        {
        
            if (notebookOpen)
            {
 
                anim.Play("Hide");
                notebookOpen = !notebookOpen;
                StartCoroutine(WaitForAnimationOver());
            }


        }
    }

    /// <summary>
    /// Call method when a new Note is added to the notebook.
    /// </summary>
    public void NotifyNoteAdded()
    {
        notebookNotify.GetComponent<Animator>().Play("Notify");   
    }

    IEnumerator WaitForAnimationOver()
    {
        animRunning = true;
        yield return new WaitForSeconds(1.6f);
        animRunning = false;
    }

    public void Say(string text)
    {
        if (text.Contains(name))
        {
            string txt = text;
            txt = txt.Replace(name, "<color=yellow>" + name + "</color");
            this.dialogTextButton.interactable = true;
            this.dialogText.text = txt;
        }
        else
        {
            this.dialogTextButton.interactable = false;
            this.dialogText.text = text;
        }

    }
}
