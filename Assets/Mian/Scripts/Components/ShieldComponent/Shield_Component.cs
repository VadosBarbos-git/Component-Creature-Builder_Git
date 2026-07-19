using UnityEngine;

public class Shield_Component : MonoBehaviour, IComponentEntity
{
    [Range(10, 100)]
    [SerializeField] private int defanceShield = 20; 
    public void Disable()
    {
        
    }

    public void Initialize(Entity entity)
    {
        
    }

    public void OnAddNewComponent(IComponentEntity component)
    {
        
    }

    public void OnRemoveComponent(IComponentEntity component)
    {
        
    }

    public void Tick()
    {
        
    }
}
