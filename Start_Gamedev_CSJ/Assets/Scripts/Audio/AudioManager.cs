using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgmMusic;

    private AudioControl audioC;

    private void Start()
    {
        audioC = FindAnyObjectByType<AudioControl>();

        audioC.PlayBGM(bgmMusic); // Play the background music
    }

}
