using UnityEngine;

/// <summary>
/// Un objeto que contiene texto
/// Se puede crear desde el project browser con click derecho > Create > TextObject
/// </summary>
[CreateAssetMenu(fileName = "TextObject", menuName = "")]
public class TextObject : ScriptableObject // los objetos derivados de ScriptableObject no pueden existir en las escenas, solo en el editor
{
    [Multiline(10)] public string text;
}