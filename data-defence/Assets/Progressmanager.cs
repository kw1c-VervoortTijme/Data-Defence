using UnityEngine;
using UnityEngine.UI;

public class Progressmanager : MonoBehaviour
{
    [SerializeField] private Slider progressBar; // Assign in the Inspector
    private float progress = 0f;

    public void IncreaseProgress(float increment)
    {
        progress += increment;
        progress = Mathf.Clamp01(progress); // Ensure it stays between 0 and 1
        if (progressBar != null)
        {
            progressBar.value = progress;
        }
        Debug.Log($"Progress updated: {progress * 100}%");
    }
}
