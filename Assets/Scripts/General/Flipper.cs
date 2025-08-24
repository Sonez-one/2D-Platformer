using UnityEngine;

public class Flipper : MonoBehaviour
{
    private readonly float _rotationDegree = 180f;

    public void Flip(bool isFacingLeft)
    {
        if (isFacingLeft)
        {
            transform.rotation = Quaternion.AngleAxis(_rotationDegree, Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
    }
}