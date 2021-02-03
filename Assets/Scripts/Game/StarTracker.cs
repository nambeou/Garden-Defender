using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarTracker : MonoBehaviour
{
    [SerializeField] int stars = 100;

    void Start()
    {
        DisplayStar();
    }

    private void DisplayStar () {
        GetComponent<TextMeshProUGUI>().text = this.stars.ToString();
    }

    public int GetStarCount() {
        return this.stars;
    }

    public void DeductStars(int amount) {
        if (this.stars >= amount) {
            this.stars -= amount;
            DisplayStar();
        }
    }
    public void AddStars(int amount) {
        this.stars += amount;
        DisplayStar();
    }

    public void InsufficientStartAlert() {
        StartCoroutine(FlickeringText(Color.red, 0.2f));
    }

    IEnumerator FlickeringText(Color color, float delay) {
        GetComponent<TextMeshProUGUI>().color = color;
        yield return new WaitForSeconds(delay);
        GetComponent<TextMeshProUGUI>().color = Color.white;

    }

}
