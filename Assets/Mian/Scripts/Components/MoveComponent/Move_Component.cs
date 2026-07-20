using UnityEngine;

public class Move_Component : MonoBehaviour, IComponentEntity
{
    [SerializeField] private float moveSpeed = 10;
    private Rigidbody rb;
    private InputSystem_Actions action;
    public void Disable()
    {
        action.Disable();
    }

    public void Initialize(Entity entity)
    {
        rb = entity.GetRB();
        action = new();
        action.Enable();
    } 
    public void Tick()
    {
        Move();
    }
    void Move()
    {
        if (action == null) return;

        Vector2 move = action.Player.Move.ReadValue<Vector2>();
        Vector3 force = new Vector3(move.x, 0, move.y) * moveSpeed;
        rb.AddForce(force);
    }
}
