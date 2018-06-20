using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternManager : MonoBehaviour {
    public Sequence Sequence;

    List<Image> Tiles;

    void Awake () {
        Tiles = PopulateTileList ();
    }

    void Start () {
        Sequence = new Sequence ();
        GenerateNewPattern ();
    }

    List<Image> PopulateTileList () {
        List<Image> aux = new List<Image> ();

        foreach (Transform t in transform) {
            if (t.tag == "Pattern Tile")
                aux.Add (t.GetComponent<Image> ());
        }

        return aux;
    }

    public void GenerateNewPattern () {
        Sequence.NewSequence ();

        if (Sequence.IsRepeatOfLastSequence () || Sequence.IsAllSameValue ()) {
            GenerateNewPattern ();
            return;
        }

        AssignColorToTiles ();
    }

    void AssignColorToTiles () {
        for (int i = 0; i < 12; i++) {
            bool IsActive = Sequence.CurrentSequence[i] == 1;

            Tiles[i].color = (IsActive) ?
                Manager.Instance.CurrentPalette.ActiveTileColor :
                Manager.Instance.CurrentPalette.InactiveTileColor;
        }
    }
}