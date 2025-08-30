using UnityEngine;

public class JumpSurfaceDetector : MonoBehaviour
{
    public bool IsJumpable { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _) || collision.gameObject.TryGetComponent<Enemy>(out _))
            IsJumpable = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _) || collision.gameObject.TryGetComponent<Enemy>(out _))
            IsJumpable = false;
    }
}