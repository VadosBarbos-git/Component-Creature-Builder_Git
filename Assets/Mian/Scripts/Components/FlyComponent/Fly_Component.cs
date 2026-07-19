using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fly_Component : MonoBehaviour, IComponentEntity
{
    private Rigidbody _rb;
    private InputSystem_Actions _inputActions;
    [SerializeField] private float forceFly = 20;
    public void Disable()
    {
        _inputActions.Disable();
    }

    public void Initialize(Entity entity)
    {
        _rb = entity.m_rigidbody;
        _inputActions = new();
        _inputActions.Enable();
    }
    public void OnAddNewComponent(IComponentEntity component)
    {

    }

    public void OnRemoveComponent(IComponentEntity component)
    {

    }

    public void Tick()
    {
        Fly();
    }
    private void Fly()
    {
        if (_inputActions.Player.Jump.IsPressed())
        {
            _rb.AddForce(Vector3.up * forceFly);
        }
    }
}
