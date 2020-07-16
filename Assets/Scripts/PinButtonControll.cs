using System.Collections;
using UnityEngine;

public class PinButtonControll : MonoBehaviour
{
    public GameObject myPin;
    public GameObject MiniGame;
    public Transform TransformParentPin;

    private float timeStamp;
    public float coolDownPeriodInSeconds = 0.5f;

    public int pinPosition;
    private int pinNumber;
    private float[] VerticalPositions;
    private int[] VictoryPinsPositions;

    // settings
    private bool HelpPositionsSound;
    private float speed;
    private float speedFalling;

    // audio
    private AudioSource AudioSource;
    private AudioClip pinMoveSound;
    private AudioClip pinFallingSound;
    private AudioClip pinTruePositionSound;
    private AudioSource AudioSource2;


    private void Start()
    {

        MiniGame = GameObject.Find("UnlockGame");
        
        VerticalPositions = MiniGame.GetComponent<UnlockGameScript>().VerticalPositions;
        pinNumber = myPin.GetComponent<PinScript>().pinNumber;
        LoadVictoryPositions();

        // settings

        HelpPositionsSound = MiniGame.GetComponent<UnlockGameScript>().HelpPositionsSound;
        speed = MiniGame.GetComponent<UnlockGameScript>().speed;
        speedFalling = MiniGame.GetComponent<UnlockGameScript>().speedFalling;


        // audio
        AudioSource = myPin.GetComponent<AudioSource>();
        pinMoveSound = myPin.GetComponent<PinScript>().pinMoveSound;
        pinFallingSound = myPin.GetComponent<PinScript>().pinFallingSound;
        pinTruePositionSound = myPin.GetComponent<PinScript>().pinTruePositionSound;
        AudioSource2 = MiniGame.GetComponent<AudioSource>();


    }
    public void OnClick()
    {
        pinPosition = myPin.GetComponent<PinScript>().pinPosition; // reload pin pos
        LoadVictoryPositions();
        if (pinPosition <= 5 && timeStamp <= Time.time && MiniGame.GetComponent<UnlockGameScript>().Victory == false)
        {
            timeStamp = Time.time + coolDownPeriodInSeconds;
            pinPosition++;

            if (pinPosition > 5) // falling down
            {
                AudioSource.clip = pinFallingSound;
                AudioSource.Play();
                pinPosition = 0;
            }
            else // moving up
            {
                AudioSource.clip = pinMoveSound;
                AudioSource.Play();
                myPin.transform.GetComponentInParent<Animation>().Play();
                if (pinPosition == VictoryPinsPositions[pinNumber] && HelpPositionsSound == true) // if help sounds = true 
                {
                    AudioSource2.clip = pinTruePositionSound;
                    AudioSource2.Play();
                }
            }
            myPin.GetComponent<PinScript>().pinPosition = pinPosition;
        }
        StartCoroutine("MovePin");
    }

    IEnumerator MovePin()
    {
        Vector3 localPos = TransformParentPin.localPosition;

        for (float ft = 10f; ft >= 0; ft -= 0.1f)
        {
            if (pinPosition == 0) // falling down
            {
                localPos = Vector3.MoveTowards(localPos, new Vector3(localPos.x, VerticalPositions[pinPosition], localPos.z), speedFalling);
                TransformParentPin.localPosition = localPos;
            }
            else // moving up
            {
                localPos = Vector3.MoveTowards(localPos, new Vector3(localPos.x, VerticalPositions[pinPosition], localPos.z), speed);
                TransformParentPin.localPosition = localPos;
            }
            yield return new WaitForFixedUpdate();
        }        
    }

    void LoadVictoryPositions()
    {
        VictoryPinsPositions = MiniGame.GetComponent<UnlockGameScript>().VictoryPinsPositions;        
    }

}
