using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{

    public GameObject CloseMiniGameButton;
    public GameObject OpenMiniGameButton;
    public GameObject BlackSmooth;
    public GameObject VictoryMessage;
    public GameObject CloseMessage;
    public GameObject RestartAndRerollButton;
    public GameObject MiniGame;
    public GameObject Safe;
    

    private void Start()
    {
        
    }

    // Buttons

    public void OpenMiniGame()
    {
        if (MiniGame.GetComponent<UnlockGameScript>().Victory == false && MiniGame.activeSelf == false)
        {
            MiniGame.SetActive(true);
            MiniGame.GetComponent<UnlockGameScript>().toDefaultPositions();
            MiniGame.GetComponent<UnlockGameScript>().StartCoroutine("DoCheck");            
            BlackSmooth.SetActive(true);            
            CloseMiniGameButton.SetActive(true);           
            MiniGame.GetComponent<UnlockGameScript>().FixPositionsAfterAnimation();
        }
    }

    public void CloseMiniGame()
    {
        if (CloseMiniGameButton.activeSelf == true)
        {
            MiniGame.SetActive(false);
            BlackSmooth.SetActive(false);
            CloseMiniGameButton.SetActive(false);
        }
    }

    public void TakeTreasureButton()
    {
        VictoryMessage.SetActive(true);
    }

    public void CloseMessageButton()
    {
        VictoryMessage.SetActive(false);
        RestartAndRerollButton.SetActive(true);
    }

    public void RestartGameButton()
    {
        MiniGame.GetComponent<UnlockGameScript>().Victory = false;
        MiniGame.GetComponent<UnlockGameScript>().VictoryPinsPositions = new int[5] { Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6) };
        MiniGame.GetComponent<UnlockGameScript>().DefaultPinsPositions = new int[5] { Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6) };
        
        RestartAndRerollButton.SetActive(false);
        Safe.SetActive(false);
        VictoryMessage.SetActive(false);
      
    }
}
