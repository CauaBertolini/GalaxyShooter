using System;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    private UImanager _uiManager;

    [SerializeField]
    private GameObject _playerLivesUI;
    private Boolean _isGameRunning = false;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _uiManager.ResetScore();
        _playerLivesUI.SetActive(false);
    }

    void Update()
    {
        if (!_isGameRunning) {
            if (Input.GetKeyDown(KeyCode.Space)) {

                _isGameRunning = true;

                this.gameObject.SetActive(false);
                _playerLivesUI.SetActive(true);

                Instantiate(_playerPrefab, new Vector3(0,0,0), quaternion.identity);

            }
        } 
    }

    public void EndTheGame() {
        _isGameRunning = false;
        this.gameObject.SetActive(true);
        _playerLivesUI.SetActive(false);
        _uiManager.ResetScore();

    }
}
