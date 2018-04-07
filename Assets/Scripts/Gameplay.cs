using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    private List<Player> players;

    [SerializeField] private GameObject playerPrefab;

    void Awake()
    {
        instance = this;
        
        players = new List<Player>();
    }

    public void RegisterNewPlayer(string playerName, bool ai)
    {
        // Decide an offset vector so they don't overlap.  
        Vector3 placementOffsetVector = Vector3.zero;
        switch (players.Count)
        {
            case 1: 
                placementOffsetVector = new Vector3(.5f, 0, 0);
                break;
            
            case 2: 
                placementOffsetVector = new Vector3(-.5f, 0, 0);
                break;
            
            case 3: 
                placementOffsetVector = new Vector3(0, 0, -.5f);
                break;
        }
        
        Player newPlayer = ((GameObject)(Instantiate(playerPrefab, PassGo.instance.transform.position + placementOffsetVector, playerPrefab.transform.rotation))).GetComponent<Player>();
        
        newPlayer.SetPlayerName(playerName);
        newPlayer.SetIsAI(ai);
        
        players.Add(newPlayer);
        
        newPlayer.Initialize();
    }

    public void StartGame()
    {
        StartCoroutine(PlayGame());
    }

    private IEnumerator PlayGame()
    {
        yield return CameraController.instance.LerpToViewBoardTarget();
        
        // Simulate taking 16 turns.  
        for (int i = 0; i < 16; i++)
        {
            foreach (Player player in players)
            {
                yield return DieRoller.instance.RollDie();
                int[] dieRollResults = DieRoller.instance.GetDieRollResults();
                
                int total = 0;
                for (int dieCount = 0; dieCount < dieRollResults.Length; dieCount++)
                    total += dieRollResults[dieCount];

                yield return player.MoveSpaces(total);
            }
        }
    }
}
