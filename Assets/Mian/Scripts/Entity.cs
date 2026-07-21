using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody3D;
    [SerializeField] private ComponentFactory componentFactory;


    private Dictionary<ComponentDefinition, IComponentEntity> _Components = new();
    private Dictionary<ComponentDefinition, GameObject> _ObjectComponents = new();


    public Rigidbody GetRB() => rigidbody3D;
    public void UpdateAppliedComponents(List<ComponentDefinition> appliedComponents)
    {
        List<ComponentDefinition> valuesForRemove = _Components.Keys.Where(a => !appliedComponents.Contains(a)).ToList(); 
        foreach (var value in valuesForRemove)
        {
            RemoveComponent(value);
        } 
        foreach (var item in appliedComponents)
        {
            if (_Components.ContainsKey(item)) continue;
            AddComponent(item);
        }
    }

    private void AddComponent(ComponentDefinition value)
    {
        if (_Components.ContainsKey(value)) return;

        GameObject obj = componentFactory.MakeComponent(value.prefab, transform);
        IComponentEntity component = obj.GetComponent<IComponentEntity>();


        component.Initialize(this);
        _Components.Add(value, component);
        _ObjectComponents.Add(value, obj);

    }
    private void RemoveComponent(ComponentDefinition key)
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
