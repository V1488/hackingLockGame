using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject Message;
    public GameObject RestartAndRerollButton;

    public void TakeTreasure()
    {
        Message.SetActive(true);
    }

    public void CloseMessage()
    {
        Message.SetActive(false);
        RestartAndRerollButton.SetActive(true);
    }

}
