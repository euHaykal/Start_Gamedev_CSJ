using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public static AudioControl instance; //Instância do AudioControl

    [SerializeField] private AudioSource audioSource; //Fonte de áudio para a música de fundo

    private void Awake()
    {
        if (instance == null) //Verifica se a instância é nula
        {
            instance = this; //Define a instância como este objeto
            DontDestroyOnLoad(instance); //Não destrói o objeto ao carregar uma nova cena
        }
        else
        {
            Destroy(gameObject); //Destrói o objeto se já houver uma instância
        }
    }

    public void PlayBGM(AudioClip audio)
    {
        audioSource.clip = audio; //Define o clipe de áudio
        audioSource.Play(); //Reproduz o áudio
    }
}
