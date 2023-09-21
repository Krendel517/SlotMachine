
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private Slot[] _slots;
    [SerializeField]
    private Slot _slot;

    private Vector2 _botPoint;
    private Vector2 _topPoint;
    private Vector2 _slotSize;

    private void Awake()
    {
        Slot.OnExitFromScreen += TeleportOfSlot;
        _slotSize = _slot.GetComponent<SpriteRenderer>().sprite.rect.size / 100;
    }

    public void MakeSlotMachin(Vector2Int size)
    {
        Vector2 offSet = new Vector2((size.x - 1) / 0.5f, (size.y - 1) / 0.5f);
        _slots = new Slot[size.x * size.y];

        for (int i = 0, x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++, i++)
            {
                Slot slot = _slots[i] = Instantiate(_slot);
                slot.transform.SetParent(transform);
                slot.transform.localPosition = new Vector2(x * (_slotSize.y + 2) - (int)offSet.x, y * _slotSize.y - offSet.y);
            }
        }

        _botPoint.y = _slots[1].transform.position.y - _slotSize.y * 2;
        _topPoint.y = _slots[_slots.Length - 1].transform.position.y;

        for (int i = 0; i < _slots.Length; i++)
            UI.OnClickPlay += _slots[i].AvailebleMoveChanger;
    }

    public void TeleportOfSlot(GameObject slot)
    {
        if (slot.transform.position.y < _botPoint.y)
            slot.transform.position = new Vector2(slot.transform.position.x, _topPoint.y);
    }
}
