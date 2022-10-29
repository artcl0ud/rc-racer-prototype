using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ControlType { HumanInput, AI }
    public ControlType controlType = ControlType.HumanInput;

    public float bestLapTime { get; private set; } = Mathf.Infinity;
    public float lastLapTime { get; private set; } = 0;
    public float currentLapTime { get; private set; } = 0;
    public int currentLap { get; private set; } = 0;

    private float lapTimerTimestamp;
    private int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;

    private CarController carController;

    void Awake()
    {
        checkpointsParent = GameObject.Find("CheckPoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carController = GetComponent<CarController>();
    }

    void Update()
    {
        currentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0;

        if(controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.inputController.SteerInput;
            carController.Throttle = GameManager.Instance.inputController.ThrottleInput;
        }
    }

    void StartLap()
    {
        currentLap++;
        lastCheckpointPassed  = 1;
        lapTimerTimestamp = Time.time;
    }

    void EndLap()
    {
        lastLapTime = Time.time - lapTimerTimestamp;
        bestLapTime = Mathf.Min(lastLapTime, bestLapTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        if(collider.gameObject.name == "1")
        {
            if(lastCheckpointPassed == checkpointCount)
            {
                EndLap();
            }

            if (currentLap == 0 || lastCheckpointPassed == checkpointCount)
            {
                StartLap();
            }
            return;
        }

        if(collider.gameObject.name == (lastCheckpointPassed + 1).ToString())
        {
            lastCheckpointPassed++;
        }
    }
}