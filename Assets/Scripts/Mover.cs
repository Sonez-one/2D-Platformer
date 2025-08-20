using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_movementSpeed * Time.deltaTime * direction, _rigidbody.velocity.y);
    }
}