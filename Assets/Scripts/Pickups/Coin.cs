using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Pickup
{
    
    [SerializeField] private int value = 100;
    ScoreManager scoreManager;
    
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.UpdateScore(value);
        //Debug.Log("Add 100 points ");
    }
}
