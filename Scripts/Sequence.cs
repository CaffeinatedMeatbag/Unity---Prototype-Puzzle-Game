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
        return new List<int> (9) { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    List<int> NewRandomSequence () {
        previousSequence = new List<int> (CurrentSequence);

        List<int> a = Enumerable.Range (0, 9).ToList ();
        List<int> b = ZeroSequence ();

        int numberOfTilesToActivate = rnd.Next (3, 8);

        Shuffle (a);

        for (int i = 0; i < numberOfTilesToActivate; i++) {
            b[a[i]] = 1;
        }

        return b;
    }

    void Shuffle<T> (IList<T> array) {
        for (int i = array.Count; i > 1;) {
            int j = rnd.Next (i);
            --i;
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}