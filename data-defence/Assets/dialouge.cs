using UnityEngine;
using TMPro;
using UnityEngine.UI; // For handling UI components like buttons
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;         // The dialogue panel object
    public TextMeshProUGUI textComponent;    // The TextMeshPro text component for dialogue
    public Button startButton;              // The Start button from the main menu
    public Button exitButton;               // The Exit button from the main menu
    public string[] lines;                  // The array of dialogue lines
    public float textSpeed;                 // Speed for the typing effect

    private int index;

    void Start()
    {
        // Initially hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Add listeners to the buttons
        startButton.onClick.AddListener(StartDialogue);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void StartDialogue()
    {
        // Hide the Start and Exit buttons when dialogue begins
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        // Show the dialogue panel and start typing the first line
        dialoguePanel.SetActive(true);
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit(); // Quits the application
    }

    void Update()
    {
        // If the dialogue panel is active, allow skipping or advancing lines
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // End of dialogue
            dialoguePanel.SetActive(false);
            Debug.Log("Dialogue finished. Game starts here...");
        }
    }
}
