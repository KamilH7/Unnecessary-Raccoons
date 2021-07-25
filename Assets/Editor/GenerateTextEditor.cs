using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextGenerator))]
public class TextGeneratorEditor : Editor
{
    string text;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TextGenerator body = (TextGenerator)target;
        text = GUILayout.TextArea("Generate This", 200);

        if (GUILayout.Button("Generate Text"))
        {  
            body.GenerateTextEditor(text, new GameObject("GeneratedText"));
        }
    }
}
