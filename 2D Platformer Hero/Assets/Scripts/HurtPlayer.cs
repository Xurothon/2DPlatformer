﻿using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;

    private LevelManager _levelManager;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _levelManager.HurtPlayer(damageToGive);
        }
    }
}
