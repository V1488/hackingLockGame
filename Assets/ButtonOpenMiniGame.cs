using UnityEngine;

public class ButtonOpenMiniGame : MonoBehaviour
{
    public GameObject MiniGame;
    public GameObject CloseButton;
    public GameObject BlackSmooth;

    public void OpenMiniGame()
    {
        if (MiniGame.GetComponent<UnlockGameScript>().Victory == false && MiniGame.activeSelf == false)
        {
            MiniGame.GetComponent<UnlockGameScript>().toDefaultPositions();
            BlackSmooth.SetActive(true);
            MiniGame.SetActive(true);
            CloseButton.SetActive(true);
        }

    }

}
