using UnityEngine;

public class Flipper : MonoBehaviour
{
    private readonly float _rotationDegree = 180f;

    private Quaternion _lookLeft;
    private Quaternion _lookRight;

    private void Start()
    {
        _lookLeft = Quaternion.AngleAxis(_rotationDegree, Vector3.up);
        _lookRight = Quaternion.AngleAxis(0, Vector3.up);
    }

    public void Flip(bool isFacingLeft)
    {
        if (isFacingLeft)
            transform.rotation = _lookLeft;
        else
            transform.rotation = _lookRight;
    }
}