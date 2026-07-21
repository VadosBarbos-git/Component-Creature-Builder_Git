using UnityEngine;

[CreateAssetMenu(fileName = "ComponentDefinition_", menuName = "ScriptableObject/ComponentDefinition")]
public class ComponentDefinition : ScriptableObject
{
    public string nameComponent;
    public GameObject prefab;
}
