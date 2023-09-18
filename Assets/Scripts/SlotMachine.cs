
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private Slot[] _slots;
    [SerializeField]
    private Slot _slot;

    public void MakeSlotMachin(Vector2Int size)
    {
        Vector2 offSet = new Vector2((size.x - 1) / 0.5f, (size.y - 1) / 0.5f);
        _slots = new Slot[size.x * size.y];

        for (int i = 0,x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++, i++)
            {
                Slot slot = _slots[i] = Instantiate(_slot);
                slot.transform.SetParent(transform);
                slot.transform.localPosition = new Vector2(x * 14 - (int)offSet.x, y * 12 - offSet.y);
            }
        }
    }
}
