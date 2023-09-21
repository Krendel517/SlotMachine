using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    Button _buttonPlay;
    [SerializeField]
    Sprite _buttonStopSpr;
    [SerializeField]
    Sprite _buttonPlaySpr;
    [SerializeField]
    TextMeshProUGUI _playButtonTxt;

    public static Action OnClickPlay;

    private void Start()
    {
        _buttonPlay.GetComponent<SpriteRenderer>();
        _buttonPlay.onClick.AddListener(PlayButton);
    }

    private void PlayButton()
    {
        if (_buttonPlay.image.sprite == _buttonPlaySpr)
            _buttonPlay.image.sprite = _buttonStopSpr;
        else
            _buttonPlay.image.sprite = _buttonPlaySpr;

        if (_buttonPlay.image.sprite == _buttonPlaySpr)
            _playButtonTxt.text = "PLAY";
        else
            _playButtonTxt.text = "STOP";

        OnClickPlay?.Invoke();
    }
}
