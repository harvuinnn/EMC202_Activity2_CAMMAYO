using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure to include this

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GameObject failPanel; // Reference to the panel containing the fail message and retry button

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        failPanel.SetActive(false); // Hide the fail panel at the start
    }

    public void ShowFailMessage()
    {
        failPanel.SetActive(true); // Show the fail panel
        Time.timeScale = 0; // Pause the game (optional)
    }
    
}
