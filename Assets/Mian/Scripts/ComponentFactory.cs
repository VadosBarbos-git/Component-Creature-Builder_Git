
using UnityEngine;


public class ComponentFactory : MonoBehaviour
{
    public GameObject MakeComponent(GameObject gameObject, Transform transform) => Instantiate(gameObject, transform);
    public void DestroyComponet(GameObject gameObject) => Destroy(gameObject);
}

