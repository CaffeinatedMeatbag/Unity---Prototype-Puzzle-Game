using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    public GameObject GameOverFade;

    TextMeshProUGUI GameOverUGUI;
    Animator Animator;

    void Awake () {
        Animator = GetComponent<Animator> ();
        GameOverUGUI = GetComponent<TextMeshProUGUI> ();
    }

    void OnEnable () {
        TimeManager.OnTimeIsUp += OnGameOver;
    }

    void OnDisable () {
        TimeManager.OnTimeIsUp -= OnGameOver;
    }

    void OnGameOver () {
        StartCoroutine ("GameOver");
    }

    IEnumerator GameOver () {
        string primaryColor = "#" + ColorUtility.ToHtmlStringRGB (Manager.Instance.CurrentPalette.TextColor);
        string secondaryColor = "#" + ColorUtility.ToHtmlStringRGB (Manager.Instance.CurrentPalette.ActiveTileColor);

        string message = "";
        message += string.Format ("<color={0}>Time's up!</color> ", primaryColor);

        GameOverFade.SetActive (true);
        Animator.SetBool ("isGameOver", true);
        GameOverUGUI.gameObject.SetActive (true);

        GameOverUGUI.text = message;

        yield return new WaitForSeconds (2f);

        int patternsSolved = Manager.Instance.SolvedManager.PatternsSolved;
        string pluralize = (patternsSolved >= 2 || patternsSolved == 0) ? "s" : "";

        message = "";
        message += string.Format ("<color={0}>You completed</color> ", primaryColor);
        message += string.Format ("<color={0}><B><U>{1}</U></B></color> ", secondaryColor, patternsSolved);
        message += string.Format ("<color={0}>pattern{1}!</color>", primaryColor, pluralize);

        GameOverUGUI.text = message;
    }
}