
using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    GameObject _slotObj;
    [SerializeField]
    private int _speed;

    private bool _availebleMove = false;
    private Vector2 _transformP;

    static public Action<GameObject> OnExitFromScreen;

    private void Update()
    {
        if (_availebleMove == true)
            MovingOfSlot();
    }

    private void MovingOfSlot()
    {
        _transformP = _slotObj.transform.position;
        transform.position = new Vector2(_transformP.x, _transformP.y - _speed * Time.deltaTime);
        OnExitFromScreen?.Invoke(_slotObj);
    }

    public void AvailebleMoveChanger()
    {
        if (_availebleMove != true)
            _availebleMove = true;
        else
            _availebleMove = false;
    }

    public void TeleportOfSlot(Vector2 botPoint, Vector2 topPoint)
    {
        if (transform.position.y <= botPoint.y)
            transform.position = new Vector2(transform.position.x, topPoint.y);
    }
}
