using UnityEngine;

public class PinScript : MonoBehaviour
{
    [Range(0, 5)] public int pinPosition;
    public int pinNumber;

    public AudioClip pinMoveSound;
    public AudioClip pinFallingSound;
    public AudioClip pinTruePositionSound;
}
