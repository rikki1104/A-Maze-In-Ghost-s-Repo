using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using Maze_Game.Saving;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
        
    public Vector3 respawnPoint;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        respawnPoint = Player.instance.transform.position;    
    }

    void SpawnPoint()
    {
        SaveManager.instance.activeSave.respawnPosition = respawnPoint;
    }
}


