using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour {
    public Palette CurrentPalette;
    public BoardManager BoardManager;
    public PatternManager PatternManager;
    public SolvedManager SolvedManager;
    public TimeManager TimeManager;

    public static Manager Instance {
        get { return instance; }
    }
    static Manager instance;

    void Awake () {
        if (instance != null && instance != this) {
            Destroy (gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad (gameObject);
    }

    void Start () {
        SetCameraBackgroundColor ();
    }

    void SetCameraBackgroundColor () {
        Camera.main.backgroundColor = CurrentPalette.BackgroundColor;
    }
}