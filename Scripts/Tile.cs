using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {
    public bool IsActive = false;

    Image background;
    Image hover;

    void Awake () {
        background = GetComponent<Image> ();
        hover = transform.GetChild (0).GetComponent<Image> ();
    }

    void Start () {
        hover.color = Manager.Instance.CurrentPalette.HoverColor;
    }

    public void SetIsActive (bool state) {
        IsActive = state;
        SetTileColor ();
    }

    public void ToggleIsActiveEvent () {
        IsActive = !IsActive;
        SetTileColor ();
        Manager.Instance.BoardManager.UpdateBoard (this);
    }

    void SetTileColor () {
        background.color = (IsActive) ?
            Manager.Instance.CurrentPalette.ActiveTileColor :
            Manager.Instance.CurrentPalette.InactiveTileColor;
    }
}