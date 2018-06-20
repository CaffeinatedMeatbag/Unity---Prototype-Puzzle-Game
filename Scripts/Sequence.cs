using System.Collections.Generic;
using System.Linq;
using Random = System.Random;
using UnityEngine;

public class Sequence {
    public List<int> CurrentSequence {
        get { return currentSequence; }
        private set { currentSequence = value; }
    }

    List<int> currentSequence = new List<int> ();
    List<int> previousSequence = new List<int> ();

    Random rnd = new Random ();

    public void NewSequence (bool? i = true) {
        previousSequence = (i == true) ? new List<int> (CurrentSequence) : previousSequence;
        CurrentSequence = (i == true) ? NewRandomSequence () : ZeroSequence ();
    }

    public bool IsRepeatOfLastSequence () {
        return previousSequence.SequenceEqual (CurrentSequence);
    }

    public bool IsAllSameValue () {
        return (CurrentSequence.All (x => x == CurrentSequence.First ()));
    }

    List<int> ZeroSequence () {
        return new List<int> (12) { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    List<int> NewRandomSequence () {
        previousSequence = new List<int> (CurrentSequence);

        List<int> listToShuffle = Enumerable.Range (0, 12).ToList ();
        List<int> newRandomSequence = ZeroSequence ();

        int numberOfTilesToActivate = rnd.Next (4, 9);

        Shuffle (listToShuffle);

        for (int i = 0; i < numberOfTilesToActivate; i++) {
            newRandomSequence[listToShuffle[i]] = 1;
        }

        return newRandomSequence;
    }

    void Shuffle<T> (IList<T> list) {
        for (int i = list.Count; i > 1;) {
            int j = rnd.Next (i);
            --i;
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}