using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public int killCount;
    public TextMeshProUGUI killCounterText;
    public GameObject portal;

    void Start()
    {
        // Load the kill count from PlayerPrefs, ensuring it doesn't go below 0.
        killCount = Mathf.Max(PlayerPrefs.GetInt("KillCount", 0), 0);
        UpdateKillCounterText();
    }


void Update()
{
    if (killCount > 5)
    {
        killCount = 5;
    }
}
    public void IncreaseKillCount()
    {
        killCount++;
        SaveKillCount();
        UpdateKillCounterText();

        if (killCount >= 5)
        {
            killCounterText.text = "The Portal is ready";
            portal.SetActive(true);
        }
    }

    public void DecreaseKillCount()
    {
        killCount = Mathf.Max(killCount - 1); // Ensure killCount doesn't go below 0
        SaveKillCount();
        UpdateKillCounterText();
    }

    void UpdateKillCounterText()
    {
        if (killCount < 10)
        {
            killCounterText.text = $"{killCount}/5";
        }
    }

    public void ResetKillCount()
    {
        killCount = 0;
        SaveKillCount();
        UpdateKillCounterText();
    }

    void SaveKillCount()
    {
        PlayerPrefs.SetInt("KillCount", killCount);
        PlayerPrefs.Save(); // Ensure PlayerPrefs is saved immediately
    }

    void OnApplicationQuit()
    {
        // Save the kill count when the application quits
        SaveKillCount();
    }
}
