using Assets.Scripts;
using Assets.Scripts.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GamePlayManager _gamePlayManager;
    [SerializeField]
    private GameMenuView _gameMenuView;
    [SerializeField]
    private StartPanelView _startPanelView;

    void Start()
    {
        _gamePlayManager.Initialize();
        _startPanelView.OnStartButtonClick += _startPanelView_OnStartButtonClick;
        _gameMenuView.OnTemperatureChanged += _gameMenuView_OnTemperatureChanged;
        _gameMenuView_OnTemperatureChanged(_gameMenuView.Temperature);
    }

    private void _gameMenuView_OnTemperatureChanged(float obj)
    {
        _gamePlayManager.SetTemperature(obj);
    }

    private void _startPanelView_OnStartButtonClick()
    {
        _gamePlayManager.gameObject.SetActive(true);
        _gameMenuView.gameObject.SetActive(true);
    }
}
