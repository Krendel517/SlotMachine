
using UnityEngine;

public class Rill : MonoBehaviour
{
    [SerializeField]
    private Symbol _symbol;
    
    private Symbol[] _symbols;
    private Vector2 _bottomPoint;
    private Vector2 _topPoint;
    private Vector2 _symbolSize;

    private void Awake()
    {
        _symbolSize = _symbol.GetComponent<RectTransform>().sizeDelta;
    }

    public void BuildSimbols(Vector2Int slotSizeY, int orderIndex)
    {
        Vector2 offSetY = new Vector2(0, (_symbolSize.y - 1) / 0.5f);
        _symbols = new Symbol[slotSizeY.y];

        for (int i = 0; i < slotSizeY.y; i++)
        {
            Symbol symbol = _symbols[i] = Instantiate(_symbol);
            symbol.transform.SetParent(transform);
            symbol.transform.position = new Vector2(transform.position.x + orderIndex * _symbolSize.x, i * _symbolSize.y + offSetY.y);
        }

        for (int i = 0; i < _symbols.Length; i++)
        {
            _symbols[i].OnExitFromScreen += TeleportOfSlot;
        }

        _bottomPoint.y = _symbols[0].transform.position.y - _symbolSize.y;
        _topPoint.y = _symbols[_symbols.Length - 1].transform.position.y;
    }

    public void AvailableMoveOfSymbols()
    {
        for (int i = 0; i < _symbols.Length; i++)
            _symbols[i].AvailebleMoveChanger();
    }

    public void TeleportOfSlot(GameObject slot)
    {
        if (slot.transform.position.y < _bottomPoint.y)
            slot.transform.position = new Vector2(slot.transform.position.x, _topPoint.y);
    }
}
