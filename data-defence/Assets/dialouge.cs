using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;        
    public TextMeshProUGUI textComponent;    
    public Button startButton;             
    public Button exitButton;               
    public string[] lines;                  
    public float textSpeed;              

    private int index;

    void Start()
    {
        
        dialoguePanel.SetActive(false);

        
        startButton.onClick.AddListener(StartDialogue);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void StartDialogue()
    {
        
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        
        dialoguePanel.SetActive(true);
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit(); 
    }

    void Update()
    {
        
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
            
            dialoguePanel.SetActive(false);
            Debug.Log("Dialogue finished. Game starts here...");
        }
    }
}
