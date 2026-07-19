using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody m_rigidbody;


    private Dictionary<Type, IComponentEntity> _Components = new();
    private Dictionary<Type, GameObject> _ObjectComponents = new();

    public void UpdateAppliedComponents(Dictionary<IComponentEntity, GameObject> appliedComponents)
    {
        List<Type> applied = appliedComponents.Keys.Select(a => a.GetType()).ToList();
        List<Type> valuesForRemuve = _Components.Keys.Where(a => !applied.Contains(a)).ToList();


        foreach (var value in valuesForRemuve)
        {
            RemuveComponent(value);
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

        GameObject obj = Instantiate(value, transform);
        IComponentEntity component = obj.GetComponent<IComponentEntity>();

        var comp = component.GetType();
        _Components.Add(comp, component);
        _ObjectComponents.Add(comp, obj);

        foreach (var item in _Components.Values)
        {
            item.OnAddNewComponent(component);
        }

        component.Initialize(this);
    }
    private void RemuveComponent(Type key)
    {
        if (!_Components.ContainsKey(key)) return;
        _Components[key].Disable();
        IComponentEntity component = _Components[key];
        _Components.Remove(key);

        Destroy(_ObjectComponents[key].gameObject);


        _ObjectComponents.Remove(key);

        foreach (var comp in _Components.Values)
        {
            comp.OnRemoveComponent(component);
        }


        /*
        _ObjectComponents.Remove(key);

        foreach (var comp in _Components.Values)
        {
            comp.OnRemoveComponent(component);
        }*/
    }

    void FixedUpdate()
    {

        foreach (var ite in _Components.Values)
        {
            ite.Tick();
        }
    }
}
