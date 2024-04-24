using UnityEngine;
using TMPro;

public class PromptManager : MonoBehaviour
{
    public static PromptManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI promptText; // Reference to a TextMeshPro text component

    private void Awake()
    {
        // Ensure there's only one instance of this manager in the scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep this alive across scene loads
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Display a specific prompt message
    public void DisplayPrompt(string message)
    {
        promptText.text = message;
    }

    // Clear any prompt message
    public void ClearPrompt()
    {
        promptText.text = "";
    }
}