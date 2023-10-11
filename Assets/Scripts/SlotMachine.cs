
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private Reel _reel;
    [SerializeField]
    private GameHUD _gameHUD;
    [SerializeField]
    private int _spaceBetweenReels;

    private Reel[] _reels;

    public void MakeSlotMachine(Vector2Int size)
    {
        _reels = new Reel[size.x];

        for (int x = 0; x < size.x; x++)
        {
            _reels[x] = Instantiate(_reel);
            _reels[x].transform.SetParent(transform);
            _reels[x].transform.localPosition = new Vector2(_reels[x].transform.position.x + x * _spaceBetweenReels, _reels[x].transform.position.y);
        }

        for (int i = 0; i < _reels.Length; i++)
        {
            _reels[i].BuildSymbols(size, i);
            _gameHUD.OnClickPlay += PlaySlot;
        }
    }

    public void PlaySlot(bool availableMove)
    {
        if (availableMove)
        {
            for (int i = 0; i < _reels.Length; i++)
            {
                _reels[i].AvailableMove = true;
                _reels[i].MoveReel();
            }
        }
        else
        {
            for (int i = 0; i < _reels.Length; i++)
                _reels[i].AvailableMove = false;
        }
    }

}
