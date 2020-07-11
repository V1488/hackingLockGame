using UnityEngine;

public class UnlockGameScript : MonoBehaviour
{
    public bool HelpPositionsSound = false;

    public bool Victory = false;
    public float speed = 0.01f;
    public float speedFalling = 0.05f;

    public GameObject AllPins;
    public GameObject Safe;

    [Range(0, 5)]
    public int[] DefaultPinsPositions = new int [5] { 0, 0, 0, 0, 0 };

    [Range(0, 5)]
    public int[] VictoryPinsPositions = new int [5] { 0, 0, 0, 0, 0 };

    [Range(0, 5)]
    public int[] CurrentPinsPositions = new int [5] { 0, 0, 0, 0, 0 };

    public float[] Positions = new float[6] { 0, 0, 0, 0, 0, 0 };

    void Start()
    {
        toDefaultPositions();
    }

    void Update()
    {
        if(Victory == false)
        {
            CurrentPositions();
            CheckVictory();
        }
    }

    public void CheckPinsPositionsOnStart()
    {
        int pinPosition;
        for (int i = 0; i < 5; i++)
        {
            for (int y = 0; y < 6; y++)
            {
                pinPosition = AllPins.transform.GetChild(i).transform.GetChild(0).GetComponent<PinScript>().pinPosition;
                if (pinPosition == y)
                {
                    AllPins.transform.GetChild(i).transform.GetChild(0).GetComponent<PinScript>().transform.localPosition = new Vector2(AllPins.transform.GetChild(i).transform.GetChild(0).GetComponent<PinScript>().transform.localPosition.x, Positions[y]);
                }
            }
        }
    }

    public void toDefaultPositions()
    {
        for (int i = 0; i < 5; i++)
        {
            AllPins.transform.GetChild(i).transform.GetChild(0).GetComponent<PinScript>().pinPosition = DefaultPinsPositions[i];
        }
        CheckPinsPositionsOnStart();
    }

    public void CurrentPositions()
    {
        for (int i = 0; i < 5; i++)
        {
            CurrentPinsPositions[i] = AllPins.transform.GetChild(i).transform.GetChild(0).GetComponent<PinScript>().pinPosition;
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
                gameObject.GetComponent<AudioSource>().Play();
                Safe.SetActive(true);                
            }
        }
    }

}
