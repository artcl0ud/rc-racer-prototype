using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text UITextCurrentLapNumber;
    public Text UITextCurrentLapTime;
    public Text UITextLastLapTime;
    public Text UITextBestLapTime;

    public Player UpdateUIForPlayer;

    private int currentLap = -1;
    private float currentTime;
    private float lastLapTime;
    private float bestLapTime;

    void Update()
    {
        if(UpdateUIForPlayer == null)
        {
            return;
        }

        if(UpdateUIForPlayer.currentLap != currentLap)
        {
            currentLap = UpdateUIForPlayer.currentLap;
            UITextCurrentLapNumber.text = $"LAP: {currentLap}";
        }

        if(UpdateUIForPlayer.currentLapTime != currentTime)
        {
            currentTime = UpdateUIForPlayer.currentLapTime;
            UITextCurrentLapTime.text = $"CURRENT: {(int)currentTime / 60}:{(currentTime) % 60:00.000}";
        }

        if(UpdateUIForPlayer.lastLapTime != lastLapTime)
        {
            lastLapTime = UpdateUIForPlayer.lastLapTime;
            UITextLastLapTime.text = $"LAST: {(int)lastLapTime / 60}:{(lastLapTime) % 60:00.000}";
        }

        if(UpdateUIForPlayer.bestLapTime != bestLapTime)
        {
            bestLapTime = UpdateUIForPlayer.bestLapTime;
            UITextBestLapTime.text = bestLapTime < 1000000 ? $"BEST: {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.000}" : "BEST: NONE";
        }
    }
}
