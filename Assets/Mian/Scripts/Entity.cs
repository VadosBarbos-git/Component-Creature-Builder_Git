using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody3D;
    [SerializeField] private ComponentFactory componentFactory;


    private Dictionary<Type, IComponentEntity> _Components = new();
    private Dictionary<Type, GameObject> _ObjectComponents = new();


    public Rigidbody GetRB() => rigidbody3D;
    public void UpdateAppliedComponents(Dictionary<IComponentEntity, GameObject> appliedComponents)
    {
        List<Type> applied = appliedComponents.Keys.Select(a => a.GetType()).ToList();
        List<Type> valuesForRemuve = _Components.Keys.Where(a => !applied.Contains(a)).ToList();


        foreach (var value in valuesForRemuve)
        {
            RemoveComponent(value);
        }

        foreach (var item in appliedComponents)
        {
            if (_Components.ContainsKey(item.Key.GetType())) continue;
            AddComponent(item.Value);
        }
    }

    private void AddComponent(GameObject value)
    {
        if (_Components.ContainsKey(value.GetComponent<IComponentEntity>().GetType())) return;

        GameObject obj = componentFactory.MakeComponent(value, transform);
        IComponentEntity component = obj.GetComponent<IComponentEntity>();

        var componentType = component.GetType();

        component.Initialize(this);
        _Components.Add(componentType, component);
        _ObjectComponents.Add(componentType, obj);

    }
    private void RemoveComponent(Type key)
    {
        if (!_Components.ContainsKey(key)) return;
        _Components[key].Disable();
        IComponentEntity component = _Components[key];
        _Components.Remove(key);

        componentFactory.DestroyComponet(_ObjectComponents[key].gameObject);
        _ObjectComponents.Remove(key);
    }

    void FixedUpdate()
    {

        foreach (var ite in _Components.Values)
        {
            ite.Tick();
        }
    }
}
