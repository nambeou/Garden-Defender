using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableZone : MonoBehaviour
{


    Defender defender;
    
    private void OnMouseDown()
    {
        if (this.defender != null) {
            AttempToPlayDefender(GetSquareClicked());
        }
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickedPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y) + 0.5f);
        return gridPos;
    }

    private void AttempToPlayDefender(Vector2 postionToSpawn) {
        StarTracker starTracker = FindObjectOfType<StarTracker>();
        if (!HasADefenderAlready(postionToSpawn) && defender.GetCost() <= starTracker.GetStarCount()) {
            SpawnDefender(postionToSpawn);
            starTracker.DeductStars(defender.GetCost());
        } else {
            starTracker.InsufficientStartAlert();
        }
    }

    private void SpawnDefender(Vector2 postionToSpawn) {
        Defender obj = Instantiate(defender, postionToSpawn, Quaternion.identity) as Defender;
        obj.transform.parent = transform;
    }

    
    public void SetSelectedDefender(Defender defender) {
        this.defender = defender;
    }

    private bool HasADefenderAlready(Vector2 postionToSpawn) {
        Defender[] defenders = FindObjectsOfType<Defender>();
        foreach (Defender defender in defenders) {
            if (defender.transform.position.Equals(postionToSpawn)) {
                return true;
            }
        } 
        return false;
    }


}
