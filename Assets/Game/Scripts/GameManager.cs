using System;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private UIManager _uiManager;
    public Boolean isGameRunning = false;

    [SerializeField]
    private GameObject _playerLivesUI;
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private AudioClip _readyToGoClip;

    private double runingTimeTimer = 0;

    public double lastRuningTimeTimer = 0;    

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.ResetScore();
        _playerLivesUI.SetActive(false);
    }

    void Update()
    {
        if (!isGameRunning) {
            if (Input.GetKeyDown(KeyCode.P)) {
                runingTimeTimer = 0;

                isGameRunning = true;
                
                AudioSource.PlayClipAtPoint(_readyToGoClip, Camera.main.transform.position);

                _uiManager.HideTitleScreen();
                _playerLivesUI.SetActive(true);

                Instantiate(_playerPrefab, new Vector3(0,0,0), quaternion.identity);

            }
        } else {
            runingTimeTimer = Time.time - lastRuningTimeTimer;
            _uiManager.UpdateTimer(runingTimeTimer);
        }
    }

    public void EndTheGame() {
        _uiManager.ShowTitleScreen();
        _playerLivesUI.SetActive(false);
        _uiManager.ResetScore();
        isGameRunning = false;
        lastRuningTimeTimer = Time.time;
    }
}
