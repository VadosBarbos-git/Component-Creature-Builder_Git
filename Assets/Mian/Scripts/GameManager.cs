using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Entity _Entity;
    [SerializeField] private ComponentManger _ComponentManager;
    void Start()
    {
        Subscriptions();
    }

    private void Subscriptions()
    {
        _ComponentManager.ChangeAppliedComponents += _Entity.UpdateAppliedComponents;
    }

}
