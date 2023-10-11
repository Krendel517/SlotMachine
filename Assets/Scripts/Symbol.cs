
using DG.Tweening;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField]
    private int _speed;

    private bool _availableMove;
    private Tween _tween;
    private Vector2 _starterPosition;

    public bool AvailableMove 
    { 
        private get { return _availableMove; } 
        set {_availableMove = value; } 
    }

    private void Start()
    {
        _starterPosition = transform.position;
    }

    public void MoveSlot(Vector2 bottomPosition, Vector2 topPosition)
    {
        _tween = _tween = transform.DOMoveY(bottomPosition.y, _speed).SetSpeedBased().SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            {
                transform.position = new Vector2(transform.position.x, topPosition.y);
                _tween = transform.DOMoveY(_starterPosition.y, _speed).SetSpeedBased().SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    if (_availableMove)
                        MoveSlot(bottomPosition, topPosition);
                    else
                        _tween.Kill();
                });
            }
        });
    }
}
