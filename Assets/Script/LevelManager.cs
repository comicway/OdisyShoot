using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    //LevelPlanet02

    [SerializeField] private GameObject[] stones;
    private Vector3[] targetPositions;
    private float positionTolerance = 0.1f;

    private void Start()
    {
        targetPositions = new Vector3[]
        {
            new Vector3(-299.2f, -1f, -301.6f),
            new Vector3(-198.4f, -1f, -198.7f),
            new Vector3(200.2f, -1f, 200.5f),
            new Vector3(299.8f, -0.5f, 297f)
        };
    }

    private bool CheckAllStonesInPosition()
    {
        for (int i = 0; i < stones.Length; i++)
        {
            float distance = Vector3.Distance(stones[i].transform.position, targetPositions[i]);
            if (distance >= positionTolerance)
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        if (CheckAllStonesInPosition())
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
