
using UnityEngine;

public class RestartAndRerollButton : MonoBehaviour
{
    public GameObject MiniGame;
    public GameObject Safe;
    public GameObject VictoryMessage;

    public void RestartGame()
    {
        MiniGame.GetComponent<UnlockGameScript>().Victory = false;
        MiniGame.GetComponent<UnlockGameScript>().VictoryPinsPositions = new int[5] { Random.Range(0,6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6)};
        MiniGame.GetComponent<UnlockGameScript>().DefaultPinsPositions = new int[5] { Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6)};
        gameObject.SetActive(false);
        Safe.SetActive(false);
        VictoryMessage.SetActive(false);
    }

}
