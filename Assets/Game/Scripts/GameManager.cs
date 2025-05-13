using System;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private UImanager _uiManager;
    public Boolean isGameRunning = false;

    [SerializeField]
    private GameObject _playerLivesUI;
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private AudioClip _readyToGoClip;
    

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _uiManager.ResetScore();
        _playerLivesUI.SetActive(false);
    }

    void Update()
    {
        if (!isGameRunning) {
            if (Input.GetKeyDown(KeyCode.Space)) {

                isGameRunning = true;
                
                AudioSource.PlayClipAtPoint(_readyToGoClip, Camera.main.transform.position);

                _uiManager.HideTitleScreen();
                _playerLivesUI.SetActive(true);

                Instantiate(_playerPrefab, new Vector3(0,0,0), quaternion.identity);

            }
        } 
    }

    public void EndTheGame() {
        _uiManager.ShowTitleScreen();
        _playerLivesUI.SetActive(false);
        _uiManager.ResetScore();
        isGameRunning = false;
    }
}
