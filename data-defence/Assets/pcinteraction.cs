using UnityEngine;

public class pcinteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;

    void Update()
    {
        // Check for interaction input when the player is nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) // Replace 'E' with your desired interaction key
        {
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("Interacted with the PC!");
        // Add your progress bar update logic here, e.g.:
        FindObjectOfType<Progressmanager>().IncreaseProgress(0.1f); // Example: Increment progress
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the PC");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left the PC");
        }
    }
}
