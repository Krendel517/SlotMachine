
using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField]
    private Symbol _symbol;
    [SerializeField]
    private RectTransform _symbolRectTrans;

    private Symbol[] _symbols;
   
    public void BuildSymbols(Vector2Int slotSizeY, int orderIndex)
    {
        Vector2 offSetY = new Vector2(0, (_symbolRectTrans.sizeDelta.x) / 0.5f);
        _symbols = new Symbol[slotSizeY.y];

        for (int i = 0; i < slotSizeY.y; i++)
        {
            _symbols[i] = Instantiate(_symbol);
            _symbols[i].transform.SetParent(transform);
            _symbols[i].transform.position = new Vector2(transform.position.x + orderIndex * _symbolRectTrans.sizeDelta.x, i * _symbolRectTrans.sizeDelta.y + offSetY.y);
        }
    }
}
