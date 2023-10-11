
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private Rill _rill;
    [SerializeField]
    private GameHUD _gameHUD;

    private Rill[] _rills;

    public void MakeSlotMachine(Vector2Int size)
    {
        _rills = new Rill[size.x];

        for (int x = 0; x < size.x; x++)
        {
            Rill rill = _rills[x] = Instantiate(_rill);
            rill.transform.SetParent(transform);
            rill.transform.localPosition = new Vector2(rill.transform.position.x + x * 12, rill.transform.position.y);
        }

        for (int i = 0; i < _rills.Length; i++)
        {
            _rills[i].BuildSimbols(size, i);
            _gameHUD.OnClickPlay += _rills[i].PlaySlot;
        }
    }
}
