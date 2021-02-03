using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] bool shield = false;
    [SerializeField] int cost = 10;

    public void AddStar(int amount) {
        FindObjectOfType<StarTracker>().AddStars(amount);
    }

    public int GetCost() {
        return this.cost;
    }

    public bool IsShieldDefender() {
        return this.shield;
    }

}
