using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public TMP_Text uiText;
    public GameObject playerInputManager;
    public int[] alivePlayers = new int[10];
    int[] playerScores = new int[10];
    public Color[] colorArray = new Color[10];

    //PlayerManager manager;
    // Start is called before the first frame update
    void Start()
    {

        var man = playerInputManager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public void addScore(int score, int playerIndex){
        //Debug.Log("ADDED SCORE " + score + " TO PLAYER: " + playerIndex);
        playerScores[playerIndex] += score;
        UpdateScoreText();
    }

    public void removeScore(int score, int playerIndex){
        //Debug.Log("REMOVED SCORE " + score + " FROM PLAYER: " + playerIndex);
        playerScores[playerIndex] -= score;
        UpdateScoreText();
    }

    public void OnPlayerJoined(PlayerInput playerInput){
        //Debug.Log("PLAYER JOINED: " + playerInput.playerIndex);
        alivePlayers[playerInput.playerIndex] = 1;
        playerInput.GetComponent<Player>().playerIndex = playerInput.playerIndex;
        //colorArray[playerInput.playerIndex] = playerInput.GetComponent<Player>().playerColor;
        UpdateScoreText();
    
    }

    public void OnPlayerLeft(PlayerInput playerInput){
        //Debug.Log("PLAYER LEFT: " + playerInput.playerIndex);
        alivePlayers[playerInput.playerIndex] = 0;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (alivePlayers[0] == 1)
        {
            string textToWrite = "";
            for (int i = 0; i < 10; i++)
            {
                if (alivePlayers[i] == 1)
                {
                    string color = ColorUtility.ToHtmlStringRGB(colorArray[i]);
                    textToWrite = textToWrite + "<color=#" + color + ">" + "Player " + i + ": " + playerScores[i] + "</color>" + "\n";
                    //Debug.Log(color);
                }
            }

            uiText.text = textToWrite;
        }

    }
}
