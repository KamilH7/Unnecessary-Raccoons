using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextGenerator))]
public class TextGeneratorEditor : Editor
{
    string text = "Generate This";
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(30);
        GUILayout.Label("Editor text generation");
        TextGenerator body = (TextGenerator)target;
        text = GUILayout.TextArea(text, 200);

        if (GUILayout.Button("Generate Text"))
        {  
            body.GenerateTextEditor(text, new GameObject("GeneratedText"));
        }
    }
}
