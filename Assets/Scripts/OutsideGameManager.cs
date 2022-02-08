using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutsideGameManager : MonoBehaviour {
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private Animator cam;
	[SerializeField]
	private Animator exitAnim;

	private bool animRunning = false;
	private bool notebookOpen = false;

	[SerializeField]
	private Button notebookNotify;
	[SerializeField]
	private string noteBookNoficiationText = "Added a new <i>Note</i> to <b>Notebook</b>";

	[SerializeField]
	private Text dialogText;
	private Button dialogTextButton;
	private string pname = "";
	private bool isAttentive = true;

	public Image loginpage;
	public Button nameSubmit;
	public InputField nameInput;

	private bool submittedText = false;
	private bool timerRunning = false;

	[SerializeField]
	private float timeUntilResponse = 15f;
	[SerializeField]
	private DialogManager dialogManager;

	[SerializeField]
	private List<string> stupidFacts = new List<string>();
	private bool submittedStupid = false;

	[SerializeField]
	private Text timerTxt;
	private float timer = 15;
	private int timer_def = 15;

	[SerializeField]
	private Image birdObjective1;
	[SerializeField]
	private Image birdObjective2;
	[SerializeField]
	private Image birdObejctive3;

	private bool[] objectivesObtained = new bool[] { false, false, false };

	[SerializeField]
	private string endingScene = "Ending Scene";

	[SerializeField]
	private int numberOfQuestions = 7;

	private bool finished;


	// Start is called before the first frame update
	void Start() {
		notebookNotify.onClick.AddListener(OpenNotebook);
		Text txt = notebookNotify.GetComponent<Text>();
		txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0f);

		dialogTextButton = dialogText.gameObject.GetComponent<Button>();
		dialogTextButton.onClick.AddListener(Attentive);
		this.dialogTextButton.interactable = false;
		this.nameSubmit.onClick.AddListener(SubmitName);
		this.timerTxt.gameObject.SetActive(false);

		this.birdObjective1.gameObject.SetActive(false);
		this.birdObjective2.gameObject.SetActive(false);
		this.birdObejctive3.gameObject.SetActive(false);


	}

	void SubmitName() {
		this.pname = this.nameInput.text;

		this.loginpage.gameObject.SetActive(false);
		dialogManager.StartEvents();
	}
	/// <summary>
	/// Alt-tab out and pay attention.
	/// </summary>
	private void Attentive() {
		cam.Play("zoom out");
		this.isAttentive = true;
	}
	/// <summary>
	/// Alt-tab in and don't pay attention.
	/// </summary>
	private void Unattentive() {
		cam.Play("zoom in");
		CloseNotebook();
		this.isAttentive = false;

	}
	/// <summary>
	/// Unlocks objective bird. 1 is the flying bird, 2 is the cage, 3 is the kiwi.
	/// </summary>
	/// <param name="number">The objective number range (1-3)</param>
	public void UnlockObjective(int number) {
		switch( number ) {
		case 1:
			this.birdObjective1.gameObject.SetActive(true);
			objectivesObtained[0] = true;
			break;
		case 2:
			this.birdObjective2.gameObject.SetActive(true);
			objectivesObtained[1] = true;
			break;
		case 3:
			objectivesObtained[2] = true;
			this.birdObejctive3.gameObject.SetActive(true);
			break;

		}

	}

	/// <summary>
	/// Gets the number of objectives achieved.
	/// </summary>
	/// <returns>The number of objectives achieved.</returns>
	public int GetObjectivesScore() {
		int count = 0;
		for( int i = 0; i < this.objectivesObtained.Length; i++ ) {
			if( this.objectivesObtained[i] ) {
				count += 1;
			}
		}
		return count;
	}

	// Update is called once per frame
	void Update() {
		if( Input.GetMouseButtonDown(0) ) {
			RaycastHit hit;
			Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

			if( Physics.Raycast(ray, out hit) ) {
				Transform objectHit = hit.transform;
				if( objectHit.CompareTag("Notebook") ) {
					if( !notebookOpen )
						OpenNotebook();
					else
						CloseNotebook();
				}
				// Do something with the object that was hit by the raycast.
			}
		}


	}

	public IEnumerator Tab() {

		if( !animRunning ) {
			{
				if( this.isAttentive ) {
					this.Unattentive();
					yield return StartCoroutine(WaitForAnimationOver());
				}
				else {
					this.Attentive();
					yield return StartCoroutine(WaitForAnimationOver());
				}
			}

			if( this.timerRunning ) {
				this.timer -= Time.deltaTime;
				timerTxt.text = ((int)this.timer).ToString() + " seconds";
			}
		}
	}

	public void OpenNotebook() {
		print("opening");
		if( !animRunning ) {
			if( !notebookOpen ) {
				anim.Play("Show");
				notebookOpen = !notebookOpen;
				StartCoroutine(WaitForAnimationOver());
			}


		}
	}
	private void CloseNotebook() {

		if( !animRunning ) {

			if( notebookOpen ) {

				anim.Play("Hide");
				notebookOpen = !notebookOpen;
				StartCoroutine(WaitForAnimationOver());
			}


		}
	}

	/// <summary>
	/// Call method when a new Note is added to the notebook.
	/// </summary>
	public void NotifyNoteAdded() {
		notebookNotify.GetComponent<Animator>().Play("Notify");
	}

	IEnumerator WaitForAnimationOver() {
		animRunning = true;
		yield return new WaitForSeconds(1.6f);
		animRunning = false;
	}

	public void Say(string text) {

		if( text.Contains("{MC}") ) {
			this.finished = false;
			this.submittedText = false;
			this.submittedStupid = false;
			string txt = text;
			txt = txt.Replace("{MC}", "<color=yellow>" + pname + "</color>");
			this.dialogTextButton.interactable = true;
			this.dialogText.text = txt;
			StartCoroutine(RunResponseTimer());
		}
		else {
			this.dialogTextButton.interactable = false;
			this.dialogText.text = text;
		}

	}


	/// <summary>
	/// Used to submit a response to question.
	/// </summary>
	public void SubmitText(string text) {
		print("Submitted:" + text);
		if( timerRunning ) {
			this.submittedText = true;
			if( stupidFacts.Contains(text) ) {
				this.submittedStupid = true;
			}
			this.timerTxt.gameObject.SetActive(false);
			if( !submittedStupid ) {
				this.Say("Teacher: Correct!");
				GameManager.Instance.Birdiness++;
			}

			else
				this.Say("Teacher: Correct! I guess. You should put that fact on your resume!");
		}

	}
	/// <summary>
	/// Runs timer after a question is asked towards player. If player does not run SubmitText() on time
	/// then 10 points removed from grade. If player manages to run SubmitText() on time, then no points removed.
	/// </summary>
	/// <returns></returns>
	IEnumerator RunResponseTimer() {
		print("Timer startered!!");
		this.timerRunning = true;
		this.timerTxt.gameObject.SetActive(true);

		yield return new WaitForSeconds(this.timeUntilResponse);
		this.timerRunning = false;
		if( submittedText ) {

		}
		else {
			GameManager.Instance.AdjustGrade(-5);
			this.Say("Teacher: Incorrect, please pay attention to the class in the future!");

		}
		submittedText = true;
		submittedStupid = true;

		finished = true;
		submittedText = false;
		submittedStupid = false;
		this.timerTxt.gameObject.SetActive(false);
		this.timer = this.timer_def;

		if( this.numberOfQuestions <= 0 ) {
			this.EndGame(3);
		}
		else {
			StartCoroutine(ResetText());
		}


	}


	IEnumerator ResetText() {
		yield return new WaitForSeconds(3);
		this.dialogText.text = "...";
	}

	public void IterateQuestionCounter() {
		this.numberOfQuestions -= 1;
	}

	public bool hasSubmitted() {
		return this.submittedText || this.submittedStupid;
	}
	public bool hasFinished() {
		return this.finished;
	}

	public void SendFinalScore(string score) {
		PlayerPrefs.SetString("score", score);

	}

	public void EndGame(float transitionOffset) {
		PlayerPrefs.SetString("score", GameManager.Instance.LetterGrade);

		StartCoroutine(delayEnd(transitionOffset));
	}
	private IEnumerator delayEnd(float offset) {
		exitAnim.Play("ExitAnim");

		yield return new WaitForSeconds(offset);
		GameManager.Instance.TabOut();
		TransitionManager.ToCredits();
	}
}
