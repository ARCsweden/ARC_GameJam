using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerInputManager;
    int[] alivePlayers = new int[10];
    int[] playerScores = new int[10];

    //PlayerManager manager;
    // Start is called before the first frame update
    void Start()
    {

        var man = playerInputManager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addScore(int score, int playerIndex){
        Debug.Log("ADDED SCORE " + score + " TO PLAYER: " + playerIndex);
        playerScores[playerIndex] += score;
    }

    public void removeScore(int score, int playerIndex){
        Debug.Log("REMOVED SCORE " + score + " FROM PLAYER: " + playerIndex);
        playerScores[playerIndex] -= score;
    }

    public void OnPlayerJoined(PlayerInput playerInput){
        Debug.Log("PLAYER JOINED: " + playerInput.playerIndex);
        alivePlayers[playerInput.playerIndex] = 1;
        playerInput.GetComponent<Player>().playerIndex = playerInput.playerIndex;
    
    }

    public void OnPlayerLeft(PlayerInput playerInput){
        Debug.Log("PLAYER LEFT: " + playerInput.playerIndex);
        alivePlayers[playerInput.playerIndex] = 0;
    }
}
