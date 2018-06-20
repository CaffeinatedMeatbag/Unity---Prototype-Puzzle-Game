using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    public static event Action<int> OnSolved = delegate { };
    public static event Action<float> OnAddTime = delegate { };

    Sequence Sequence = new Sequence ();
    List<Tile> Tiles = new List<Tile>();

    CanvasGroup Canvas;

    void Awake () {
        Canvas = GetComponent<CanvasGroup> ();
    }

    void Start () {
        PopulateTileList ();
        GenerateNewBoard ();
    }

    void PopulateTileList () {
        Tiles = new List<Tile> (9);

        foreach (Transform t in transform) {
            if (t.tag == "Tile") {
                Tiles.Add (t.GetComponent<Tile> ());
            }
        }
    }

    void GenerateNewBoard () {
        Sequence.NewSequence (false);

        for (int i = 0; i < Sequence.CurrentSequence.Count; i++) {
            Tiles[i].SetIsActive (Sequence.CurrentSequence[i] == 1);
        }
    }

    public void UpdateBoard (Tile t) {
        if (Tiles.Contains (t)) {
            int i = Tiles.IndexOf (t);
            Sequence.CurrentSequence[i] = Convert.ToInt32 (t.IsActive);
        }

        StartCoroutine (Compare ());
    }

    IEnumerator Compare () {
        if (Sequence.CurrentSequence.SequenceEqual (Manager.Instance.PatternManager.Sequence.CurrentSequence)) {
            Canvas.blocksRaycasts = !Canvas.blocksRaycasts;
            yield return new WaitForSeconds (0.25f);
            Canvas.blocksRaycasts = !Canvas.blocksRaycasts;
  
            OnSolved (1);
            OnAddTime (2f);

            GenerateNewBoard ();
            Manager.Instance.PatternManager.GenerateNewPattern ();
        }
    }
}