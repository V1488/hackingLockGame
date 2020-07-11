using UnityEngine;

public class PinButtonControll : MonoBehaviour
{
    public GameObject myPin;
    public GameObject MiniGame;
    public GameObject parentPin;

    public float timeStamp;
    public float coolDownPeriodInSeconds = 0.01f;


    private void Start()
    {
        MiniGame = GameObject.Find("UnlockGame");
    }
    public void ButtonToMovePin()
    {
        if (myPin.GetComponent<PinScript>().pinPosition <= 5 && timeStamp <= Time.time && MiniGame.GetComponent<UnlockGameScript>().Victory == false)
        {
            timeStamp = Time.time + coolDownPeriodInSeconds;
            myPin.GetComponent<PinScript>().pinPosition++;
            
            if (myPin.GetComponent<PinScript>().pinPosition > 5)
            {
                myPin.GetComponent<AudioSource>().clip = myPin.GetComponent<PinScript>().pinFallingSound;
                myPin.GetComponent<AudioSource>().Play();
                myPin.GetComponent<PinScript>().pinPosition = 0;
            }
            else
            {
                myPin.GetComponent<AudioSource>().clip = myPin.GetComponent<PinScript>().pinMoveSound;
                myPin.GetComponent<AudioSource>().Play();
                myPin.transform.GetComponentInParent<Animation>().Play();
                if (myPin.GetComponent<PinScript>().pinPosition == MiniGame.GetComponent<UnlockGameScript>().VictoryPinsPositions[myPin.GetComponent<PinScript>().pinNumber] && MiniGame.GetComponent<UnlockGameScript>().HelpPositionsSound == true)
                {
                    myPin.GetComponent<AudioSource>().clip = myPin.GetComponent<PinScript>().pinTruePositionSound;
                    myPin.GetComponent<AudioSource>().Play();
                }
            }            
        }
    }

    void Update()
    {        
        MovePin();
    }

    void MovePin()
    {
        int pinPosition;
        pinPosition = myPin.GetComponent<PinScript>().pinPosition;
        Transform pinTransformPositions = myPin.GetComponent<Transform>().transform;
        if (pinPosition == 0) // falling down
        {
            myPin.GetComponent<Transform>().transform.localPosition = Vector3.MoveTowards(myPin.GetComponent<Transform>().transform.localPosition, new Vector3(pinTransformPositions.transform.localPosition.x, MiniGame.GetComponent<UnlockGameScript>().Positions[pinPosition], pinTransformPositions.transform.localPosition.z), MiniGame.GetComponent<UnlockGameScript>().speedFalling);
        }
        else // moving up
        {
            myPin.GetComponent<Transform>().transform.localPosition = Vector3.MoveTowards(myPin.GetComponent<Transform>().transform.localPosition, new Vector3(pinTransformPositions.transform.localPosition.x, MiniGame.GetComponent<UnlockGameScript>().Positions[pinPosition], pinTransformPositions.transform.localPosition.z), MiniGame.GetComponent<UnlockGameScript>().speed);

        }
        
    }

}
