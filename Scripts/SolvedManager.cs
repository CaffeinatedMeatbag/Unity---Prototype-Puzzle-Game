using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SolvedManager : MonoBehaviour {
	public int PatternsSolved {
		get { return patternsSolved; }
		private set { patternsSolved = value; }
	}

	int patternsSolved;
	TextMeshProUGUI patternsSolvedUGUI;

	void Awake () {
		patternsSolvedUGUI = GetComponent<TextMeshProUGUI> ();
	}

	void OnEnable () {
		BoardManager.OnSolved += OnSolved;
	}

	void OnDisable () {
		BoardManager.OnSolved -= OnSolved;
	}

	void OnSolved (int amount) {
		PatternsSolved += amount;
		UpdatePatternsSolvedUGUI ();
	}

	void UpdatePatternsSolvedUGUI () {
		patternsSolvedUGUI.text = string.Format ("{0}", PatternsSolved);
	}
}