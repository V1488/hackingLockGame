using System;
using System.Collections;
using UnityEngine;

public class UnlockGameScript : MonoBehaviour
{
    public bool HelpPositionsSound = false;

    public bool Victory = false;
    public float speed = 0.01f;
    public float speedFalling = 0.05f;

    public Transform AllPins;
    public Transform AllPinsButtonsControll;
    public GameObject Safe;

    public AudioClip VictorySound;
    public AudioSource audioSource;


    [Range(0, 5)]
    public int[] DefaultPinsPositions = new int [5] { 0, 0, 0, 0, 0 };

    [Range(0, 5)]
    public int[] VictoryPinsPositions = new int [5] { 0, 0, 0, 0, 0 };

    [Range(0, 5)]
    public int[] CurrentPinsPositions = new int [5] { 0, 0, 0, 0, 0 };

    public float[] VerticalPositions = new float[6] { 0, 0, 0, 0, 0, 0 };

    void Start()
    {
        toDefaultPositions();
        CurrentPositions();
    }


    public void CheckPinsPositionsOnStart()
    {
        int pinPosition;
        for (int i = 0; i < 5; i++)
        {
            for (int y = 0; y < 6; y++)
            {
                pinPosition = AllPins.GetChild(i).GetChild(0).GetComponent<PinScript>().pinPosition;
                if (pinPosition == y)
                {
                    AllPins.GetChild(i).GetComponent<Transform>().localPosition = new Vector2(AllPins.GetChild(i).GetComponent<Transform>().localPosition.x, VerticalPositions[y]);
                }
            }
        }
    }

    public void toDefaultPositions()
    {
        for (int i = 0; i < 5; i++)
        {
            AllPins.GetChild(i).GetChild(0).GetComponent<PinScript>().pinPosition = DefaultPinsPositions[i];
        }
        CheckPinsPositionsOnStart();
    }

    public void CurrentPositions()
    {
        for (int i = 0; i < 5; i++)
        {
            CurrentPinsPositions[i] = AllPins.GetChild(i).GetChild(0).GetComponent<PinScript>().pinPosition;
        }
    }

    public void CheckVictory()
    {
        int check = 0;
        for(int i = 0; i < 5; i++)
        {
            if(CurrentPinsPositions[i] == VictoryPinsPositions[i])
            {
                check++;
            }
            if (check >= 5)
            {
                Victory = true;
                audioSource.clip = VictorySound;
                audioSource.Play();
                Safe.SetActive(true);                
            }
        }
    }

    IEnumerator DoCheck()
    {
        for (;;)
        {
            if(Victory == false)
            {
                CurrentPositions();
                CheckVictory();
            }
            yield return new WaitForSeconds(.1f);
        }
        
    }

    public void FixPositionsAfterAnimation()
    {
        for (int i = 0; i < 5; i++)
        {
            AllPins.GetChild(i).GetChild(0).GetComponent<Transform>().localPosition = new Vector2(AllPins.GetChild(i).GetChild(0).GetComponent<Transform>().localPosition.x, 0f);
        }
        
    }
}
