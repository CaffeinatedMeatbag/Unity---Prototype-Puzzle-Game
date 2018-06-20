using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour {
    public Palette CurrentPalette;
    public BoardManager BoardManager;
    public PatternManager PatternManager;
    public SolvedManager SolvedManager;

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

    void SetCameraBackgroundColor () {
        Camera.main.backgroundColor = CurrentPalette.BackgroundColor;
    }

    void Start () {
        SetCameraBackgroundColor ();
    }
}