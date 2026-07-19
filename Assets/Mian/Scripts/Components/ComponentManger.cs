
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ComponentManger : MonoBehaviour
{
    [SerializeField] private Entity _Entity;
    [SerializeField] private List<GameObject> AllComponents;
    public event Action<Dictionary<IComponentEntity, GameObject>> ChangeAppliedComponents;

    private Dictionary<IComponentEntity, GameObject> _allComponents;
    private Dictionary<IComponentEntity, GameObject> _appliedComponents;
    private Dictionary<IComponentEntity, GameObject> _notAppliedComponents;


    public void PutComponentOnSide(PanelSide side, IComponentEntity component)
    {
        if (side == PanelSide.NotAppliedComponents)
        {
            if (!_appliedComponents.ContainsKey(component)) return;

            GameObject obj = _allComponents[component];
            _notAppliedComponents.Add(component, obj);
            _appliedComponents.Remove(component);
        }
        else
        {
            if (!_notAppliedComponents.ContainsKey(component)) return;

            GameObject obj = _notAppliedComponents[component];
            _appliedComponents.Add(component, obj);
            _notAppliedComponents.Remove(component);

        }
        ChangeAppliedComponents?.Invoke(_appliedComponents);
    }
    public List<IComponentEntity> GetNotAppliedComponents() => _notAppliedComponents.Keys.ToList();
    public List<IComponentEntity> GetAppliedComponents() => _appliedComponents.Keys.ToList();
    public void Init()
    {
        _allComponents = new();
        _appliedComponents = new();
        _notAppliedComponents = new();
        foreach (var item in AllComponents)
        {
            if (item.TryGetComponent<IComponentEntity>(out var component))
            {
                _allComponents.Add(component, item);
            }
        }

        _putAllComponentsInNotApplied();
    }
    private void _putAllComponentsInNotApplied()
    {
        _notAppliedComponents.Clear();
        _notAppliedComponents.AddRange(_allComponents);
    }


}
