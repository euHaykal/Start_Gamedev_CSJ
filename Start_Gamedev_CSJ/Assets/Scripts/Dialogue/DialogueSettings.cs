using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogie/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;  //Referencia o personagem falante

    [Header("Dialogue")]
    public Sprite speakerSprite;  //Imagem de quem fala
    public string sentence;  //Fala do diálogo

    public List<Sentences> dialogue = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;  //Nome do personagem falante
    public Sprite profile;
    public Languages sentence;  //Qual lingua está sendo utilizada pelo texto
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}
