
using DG.Tweening;
using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField]
    private Symbol _symbol;
    [SerializeField]
    private RectTransform _symbolRectTrans;
    [SerializeField]
    private int _speed;

    private Symbol[] _symbols;
    private Vector2 _bottomPoint;
    private Vector2 _topPoint;
    private bool _availableMove;
    private Tween _tween;

    public bool AvailableMove
    {
        private get { return _availableMove; }
        set { _availableMove = value; }
    }

    public void BuildSymbols(Vector2Int slotSizeY, int orderIndex)
    {
        Vector2 offSetY = new Vector2(0, (_symbolRectTrans.sizeDelta.x - 1) / 0.5f);
        _symbols = new Symbol[slotSizeY.y];

        for (int i = 0; i < slotSizeY.y; i++)
        {
            _symbols[i] = Instantiate(_symbol);
            _symbols[i].transform.SetParent(transform);
            _symbols[i].transform.position = new Vector2(transform.position.x + orderIndex * _symbolRectTrans.sizeDelta.x, i * _symbolRectTrans.sizeDelta.y + offSetY.y);
        }

        _bottomPoint.y = _symbols[0].transform.position.y - _symbolRectTrans.sizeDelta.y;
        _topPoint.y = _symbols[_symbols.Length - 1].transform.position.y;

        for (int i = 0; i < _symbols.Length; i++)
        {
            _symbols[i].BottomPoint = _bottomPoint;
            _symbols[i].TopPoint = _topPoint;
        }
    }

    public void MoveReel()
    {
        _tween = transform.DOMoveY(_bottomPoint.y, _speed).SetSpeedBased().SetEase(Ease.Linear)
        .OnComplete(() => MoveSymbolInStarterPosition());
    }

    private void MoveSymbolInStarterPosition()
    {
        _tween = transform.DOMoveY(_bottomPoint.y, _speed).SetSpeedBased().SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            if (_availableMove)
                MoveReel();
            else
                _tween.Kill();
        });
    }
}
