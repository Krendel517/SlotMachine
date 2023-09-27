
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private Symbol _symbol;
    [SerializeField]
    private Rill _rill;

    private Rill[] _rills;
    private Vector2 _symbolSize;

    private void Awake()
    {
        _symbolSize = _symbol.GetComponent<RectTransform>().sizeDelta;
    }

    public void MakeSlotMachin(Vector2Int size)
    {
        _rills = new Rill[size.x];

        for (int x = 0; x < size.x; x++)
        {
            Rill rill = _rills[x] = Instantiate(_rill);
            rill.transform.SetParent(transform);
            rill.transform.localPosition = new Vector2(rill.transform.position.x + x * 12, rill.transform.position.y);
        }

        for (int i = 0; i < _rills.Length; i++)
            _rills[i].BuildSimbols(size, i);

    }
}
