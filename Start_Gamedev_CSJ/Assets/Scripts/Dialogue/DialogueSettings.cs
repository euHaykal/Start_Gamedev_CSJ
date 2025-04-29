using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogie/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;  //Referencia o personagem falante

    [Header("Dialogue")]
    public Sprite speakerSprite;  //Imagem de quem fala
    public string sentence;  //Fala do diálogo

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences  //Armazena as falas
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

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (ds.sentence != "")
            {
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}
#endif