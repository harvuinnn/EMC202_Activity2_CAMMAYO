using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public int coinCount = 0; // Variable to store the coin count
    public TextMeshProUGUI coinCountText; // Reference to the UI TextMeshPro component

    private void Start()
    {
        UpdateCoinCountText(); // Update the UI text at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Increment coin count and update UI
            coinCount++;
            UpdateCoinCountText();
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Show fail panel
            GameManager.Instance.ShowFailMessage();
        }
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "" + coinCount; // Update the UI text
    }
}
