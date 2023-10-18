
using DG.Tweening;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private Transform _mainReelsPackage;
    [SerializeField]
    private int _speed;
    [SerializeField]
    private RectTransform _symbolSize;
    [SerializeField]
    private Reel _reelPrefab;
    [SerializeField]
    private GameHUD _gameHUD;
    [SerializeField]
    private int _spaceBetweenReels;


    private Transform _reelsPackageSecond;
    private Reel[] _reelsOfFirstPackage;
    private Reel[] _reelsOfSecondPackage;

    private Tween _tween;
    private bool _isAvailableMove;
    private Vector2 _bottomPosition;
    private Vector2 _topPosition;
    private Vector2 _mainScreenPosition;

    public void MakeSlotMachine(Vector2Int size)
    {
        _reelsOfFirstPackage = new Reel[size.x];
        _reelsOfSecondPackage = new Reel[size.x];
        _gameHUD.OnClickPlay += PlaySlotMachine;

        _reelsPackageSecond = Instantiate(_mainReelsPackage.transform);
        _reelsPackageSecond.SetParent(transform);

        BuildPackageOfReels(_reelsOfFirstPackage, size, _mainReelsPackage.transform);
        BuildPackageOfReels(_reelsOfSecondPackage, size, _reelsPackageSecond);

        _reelsPackageSecond.position = new Vector2(transform.position.x, transform.position.y + _symbolSize.sizeDelta.y * size.y);

        AutorizeVariable(size);
    }

    private void BuildPackageOfReels(Reel[] reels, Vector2Int size, Transform reelPackage)
    {
        reelPackage.position = transform.position;

        for (int i = 0; i < size.x; i++)
        {
            reels[i] = Instantiate(_reelPrefab);
            reels[i].transform.SetParent(reelPackage);
            reels[i].transform.localPosition = new Vector2(reels[i].transform.position.x + i * _spaceBetweenReels, reels[i].transform.position.y);
        }

        for (int i = 0; i < reels.Length; i++)
            reels[i].BuildSymbols(size, i);
    }

    private void PlayAnimationOfPackage(Transform package)
    {
        _tween = package.DOMoveY(_bottomPosition.y, _speed).SetSpeedBased().SetEase(Ease.Linear)
        .OnComplete(() => ValidateAnimationCycle(package));
    }

    private void ValidateAnimationCycle(Transform package)
    {
        package.position = new Vector2(transform.position.x, _topPosition.y);

        if (_isAvailableMove)
            PlayAnimationOfPackage(package);
        else
            _tween = package.transform.DOMoveY(_mainScreenPosition.y, _speed).SetSpeedBased().SetEase(Ease.Linear)
            .OnComplete(() => _tween.Kill());
    }

    private void PlaySlotMachine(bool buttonState)
    {
        if (buttonState)
        {
            PlayAnimationOfPackage(_mainReelsPackage);
            PlayAnimationOfPackage(_reelsPackageSecond);
            _isAvailableMove = true;
        }
        else
        {
            _isAvailableMove = false;
        }
    }

    private void AutorizeVariable(Vector2 size)
    {
        _bottomPosition.y = transform.position.y - _symbolSize.sizeDelta.y * size.y;
        _topPosition.y = transform.position.y + _symbolSize.sizeDelta.y * size.y;
        _mainScreenPosition = _mainReelsPackage.transform.position;
    }
}
