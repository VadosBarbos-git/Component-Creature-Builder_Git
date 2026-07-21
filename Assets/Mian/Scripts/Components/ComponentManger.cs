
using System;
using System.Collections.Generic; 
using UnityEngine;

public class ComponentManger : MonoBehaviour
{
    [SerializeField] private Entity _Entity;
    [SerializeField] private List<ComponentDefinition> AllComponents;
    public event Action<List<ComponentDefinition>> ChangeAppliedComponents;

    private List<ComponentDefinition> _allComponents;
    private List<ComponentDefinition> _appliedComponents;
    private List<ComponentDefinition> _notAppliedComponents;


    public void PutComponentOnSide(PanelSide side, ComponentDefinition component)
    {
        if (side == PanelSide.NotAppliedComponents)
        {
            if (!_appliedComponents.Contains(component)) return;

            _notAppliedComponents.Add(component);
            _appliedComponents.Remove(component);
        }
        else
        {
            if (!_notAppliedComponents.Contains(component)) return;

            _appliedComponents.Add(component);
            _notAppliedComponents.Remove(component);

        }
        ChangeAppliedComponents?.Invoke(_appliedComponents);
    }
    public List<ComponentDefinition> GetNotAppliedComponents() => _notAppliedComponents;
    public List<ComponentDefinition> GetAppliedComponents() => _appliedComponents;
    public void Init()
    {
        _allComponents = new();
        _appliedComponents = new();
        _notAppliedComponents = new();
        foreach (var item in AllComponents)
        {
            if (item != null && !_allComponents.Contains(item))
            {
                _allComponents.Add(item);
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
