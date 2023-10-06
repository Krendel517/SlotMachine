
using System;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField]
    private int _speed;

    private bool _availebleMove = false;
    public event Action<GameObject> OnExitFromScreen;

    private void Update()
    {
        if (_availebleMove == true)
            MovingOfSlot();
    }

    private void MovingOfSlot()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.fixedDeltaTime * _speed);
        OnExitFromScreen?.Invoke(transform.gameObject);
    }

    public void AvailebleMoveChanger()
    {
        if (_availebleMove != true)
            _availebleMove = true;
        else
            _availebleMove = false;
    }
}
