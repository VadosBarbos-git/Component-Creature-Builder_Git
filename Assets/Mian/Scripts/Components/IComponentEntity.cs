
public interface IComponentEntity
{
    public void Initialize(Entity entity);
    public void Tick();
    public void Disable();
    public void OnAddNewComponent(IComponentEntity component);
    public void OnRemoveComponent(IComponentEntity component);
}
