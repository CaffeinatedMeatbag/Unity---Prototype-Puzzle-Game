using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public static event Action OnTimeIsUp = delegate { };

    public float TimeRemaining {
        get { return timeRemaining; }
        private set { timeRemaining = value; }
    }
    private float timeRemaining = 8f;

    TextMeshProUGUI timeUGUI;

    void Awake () {
        timeUGUI = GetComponent<TextMeshProUGUI> ();
        UpdateTimeUGUI ();
    }

    void OnEnable () {
        BoardManager.OnAddTime += OnAddTime;
    }

    void OnDisable () {
        BoardManager.OnAddTime -= OnAddTime;
    }

    void Start () {
        StartCoroutine ("Countdown");
    }

    void OnSubtractTime (float amount) {
        TimeRemaining -= amount;
        UpdateTimeUGUI ();
    }

    void OnAddTime (float amount) {
        if (TimeRemaining != 0) {
            TimeRemaining += amount;
            UpdateTimeUGUI ();
        }
    }

    void UpdateTimeUGUI () {
        if (TimeRemaining <= 0) {
            TimeRemaining = 0;

            StopCoroutine ("Countdown");
            OnTimeIsUp ();
        }

        timeUGUI.text = TimeRemaining.ToString ("0.0");
    }

    IEnumerator Countdown () {
        while (TimeRemaining > 0) {
            OnSubtractTime (0.1f);
            yield return new WaitForSeconds (0.1f);
        }
    }
}