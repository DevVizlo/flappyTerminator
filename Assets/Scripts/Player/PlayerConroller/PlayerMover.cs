using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _flightBoundarynd = 4;

    public void MoveUp(bool isMove)
    {
        if (transform.position.y <= _flightBoundarynd)
        {
            if (isMove)
                transform.position += new Vector3(0, _speed * Time.deltaTime, 0);
        }
    }

    public void MoveDown(bool isMove)
    {
        if (transform.position.y >= -_flightBoundarynd)
        {
            if (isMove)
                transform.position += new Vector3(0, -_speed * Time.deltaTime, 0);
        }
    }
}
