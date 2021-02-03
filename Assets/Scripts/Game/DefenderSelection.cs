using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSelection : MonoBehaviour
{

    [SerializeField] Defender defenderPrefab;
    Color currentColor;
    Color tilted;

    private void Start()
    {
        this.currentColor = GetComponent<SpriteRenderer>().color;
        this.tilted = this.currentColor;
    }

    private void OnMouseDown()
    {
        ChangeColor();
    }

    private void SetDefender(Defender defender) {
        FindObjectOfType<PlayableZone>().SetSelectedDefender(defender);
    }

    public void ChangeColor() {
        if (currentColor.Equals(Color.white)) {
            GetComponent<SpriteRenderer>().color = tilted;
            currentColor = tilted;
            SetDefender(null);
        } else {
            GetComponent<SpriteRenderer>().color = Color.white;
            currentColor = Color.white;
            TurnOffOtherSelection();
            SetDefender(this.defenderPrefab);
        }
    }

    public Color GetCurrentColor() {
        return currentColor;
    }

    private void TurnOffOtherSelection() {
        foreach (DefenderSelection selection in FindObjectsOfType<DefenderSelection>()) {
            if (!selection.Equals(this)) {
                if (selection.GetCurrentColor().Equals(Color.white)) {
                    selection.ChangeColor();
                }
            }
        }
    }
}
