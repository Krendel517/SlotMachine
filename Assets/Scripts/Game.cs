
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Vector2Int _size;
    [SerializeField]
    private SlotMachine _slotMachine;

    private void Start()
    {
        _slotMachine.MakeSlotMachin(_size);
    }
}
