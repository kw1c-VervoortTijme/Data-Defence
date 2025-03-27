using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour

{

    public GameObject popupPanel; // Reference to the pop-up panel
    public Slider progressBar; // Reference to the progress bar
    public float popupIntervalMin = 5f; // Minimum time for random pop-ups
    public float popupIntervalMax = 15f; // Maximum time for random pop-ups
    private float nextPopupTime;

    void Start()
    {
        // Set the first random time for the pop-up
        ScheduleNextPopup();
    }

    void Update()
    {
        // Check if it's time to show a new pop-up
        if (Time.time >= nextPopupTime)
        {
            ShowPopup();
            ScheduleNextPopup();
        }
    }

    void ScheduleNextPopup()
    {
        // Set the time for the next pop-up
        nextPopupTime = Time.time + Random.Range(popupIntervalMin, popupIntervalMax);
    }

    public void ShowPopup()
    {
        popupPanel.SetActive(true); // Show the panel
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make cursor visible
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false); // Hide the panel
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide cursor

        // Increase the progress bar by 3%
        progressBar.value += 3f;

        // Clamp progress bar to its max value
        if (progressBar.value > progressBar.maxValue)
            progressBar.value = progressBar.maxValue;
    }
}
