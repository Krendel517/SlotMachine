
using UnityEngine;

public class Symbol : MonoBehaviour
{
    private Vector2 _topPoint;
    private Vector2 _bottomPoint;

    public Vector2 TopPoint
    {
        private get { return _topPoint; }
        set { _topPoint = value; }
    }
    public Vector2 BottomPoint
    {
        private get { return _bottomPoint; }
        set { _bottomPoint = value; }
    }

    private void Update()
    {
        if (transform.position.y < _bottomPoint.y)
            transform.position = new Vector2(transform.position.x, _topPoint.y);;
    }
}
