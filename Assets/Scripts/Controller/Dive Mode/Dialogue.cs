using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    public string[] DialogueStrings;
    public float SecondsBetweenCharacters = 0.15f;
    public float CharacterRateMultiplier = 0.5f;

    private Text _textComponent;
    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndOfDialogue = false;
    private string idFish;

    public Sprite image;
    public Image imageFish;
    public GameObject txtFish;
    public GameObject panelInformation;

    // Use this for initialization
    void Start ()
	{
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        
        _textComponent = GetComponent<Text>();
	    _textComponent.text = " ";
	}
	
	// Update is called once per frame
	void Update () 
	{
        FirebaseDatabase.DefaultInstance.GetReference("Fauna").GetValueAsync().ContinueWith(task => {
            DataSnapshot snapshot = task.Result;
            DialogueStrings[1] = "Fish Name: " + snapshot.Child(idFish + "/nama ikan").Value.ToString();
            DialogueStrings[2] = "Scientific Name: " + snapshot.Child(idFish + "/nama ilmiah").Value.ToString();
            DialogueStrings[3] = "Lifespan: " + snapshot.Child(idFish + "/lama hidup").Value.ToString();
            DialogueStrings[4] = "Fun Fact: " + snapshot.Child(idFish + "/fakta unik").Value.ToString();
        });
        
        if (!_isDialoguePlaying)
	    {
            _isDialoguePlaying = true;
            StartCoroutine(StartDialogue());
        }
	        
	}

    public void informationText(string id)
    {
        _isStringBeingRevealed = false;
        _isDialoguePlaying = false;
        _isEndOfDialogue = false;
        panelInformation.SetActive(true);
        txtFish.SetActive(true);
        idFish = id;
        image = Resources.Load<Sprite>("ImageFish/" + id);
        imageFish.sprite = image;
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    _isEndOfDialogue = true;
                }
            }

            yield return 0;
        }

        _isEndOfDialogue = false;
        _isDialoguePlaying = false;
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength            = stringToDisplay.Length;
        int currentCharacterIndex   = 0;
        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex <= stringLength)
            {
                yield return new WaitForSeconds(SecondsBetweenCharacters*CharacterRateMultiplier);
            }
            else { break; }
        }

        yield return new WaitForSeconds(3f);
        _isStringBeingRevealed = false;
        _textComponent.text = "";
    }
}
