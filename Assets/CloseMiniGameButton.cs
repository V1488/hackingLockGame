using UnityEngine;

public class CloseMiniGameButton : MonoBehaviour
{
    public GameObject MiniGame;
    public GameObject BlackSmooth;

    
    public void CloseMiniGame()
    {
        if (MiniGame.activeSelf == true)
        {
            MiniGame.SetActive(false);
            BlackSmooth.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
