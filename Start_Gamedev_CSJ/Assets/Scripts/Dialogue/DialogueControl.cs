using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        en,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;  //janela do diálogo
    public Image profileSprite;  //Sprite do perfil
    public Text speechText;  //Texto da fala
    public Text actorNameText;  //Nome do NPC

    [Header("Settings")]
    public float typingSpeed;  //Velocidade da fala

    #region Variáveis de Controle
    private bool isShowing;  //Se a janela está visível
    private int index;  //Index das sentenças
    private string[] sentences;
    #endregion

    public static DialogueControl instance;

    private void Awake()  //Chamado antes de todos os Starts() na hierarquia de execução de Scripts
    {
        instance = this;  //
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()  //Pular para a próxima frase/fala
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else  //Quando terminar os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    public void Speech(string[] txt)  //Chamar a fala do NPC
    {
        if(!isShowing)  //Enquanto estiver falando, não chama ação novamente
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

}
