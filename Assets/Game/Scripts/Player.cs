using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;

    public bool canTripleShoot = false;
    public bool isSpeedBoostActivate = false; 

    public bool isShieldActivate = false;
    public int _lifeHp = 3;
    
    [SerializeField]
    private float _speed = 7f;

    [SerializeField]    
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    AudioSource[] _audioSources;

    [SerializeField]
    private AudioClip _defeatClip;
    [SerializeField]
    private AudioClip _hitClip;

    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _trippleShootPrefab;

    [SerializeField]
    private GameObject _shieldGameObject;
    [SerializeField]
    private GameObject[] _fireEngines;
    

    void Start()
    {
        Debug.Log("X pos: " + transform.position.x + " Y pos: " + transform.position.y + " Z pos: " + transform.position);
        Debug.Log("Player iniciado");
        transform.position = new Vector3(0, 0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager != null) {
            _spawnManager.StartSpawnCoroutines();
        }

        if (_uiManager != null) {
            _uiManager.UpdateLives(_lifeHp);
        }

        _audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
            Shoot();
        }
        Movement();
    }

    public void Shoot() {
         if (Time.time > _canFire) {

            _audioSources[0].Play();
            
            if (canTripleShoot) {
                Instantiate(_trippleShootPrefab, transform.position + new Vector3(-0.476f, 0.027f, 0), Quaternion.identity);
                //Instantiate(_laserPrefab, transform.position + new Vector3(0.394f, 0.092f, 0), Quaternion.identity);
                //Instantiate(_laserPrefab, transform.position + new Vector3(-0.389f, 0.092f, 0), Quaternion.identity);
            } else {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.76f, 0), Quaternion.identity);
            }
            
            _canFire = Time.time + _fireRate;
        }
    }
    private void Movement() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if (isSpeedBoostActivate) 
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * 1.5f * horizontalInput);
            transform.Translate(Vector3.up * _speed * 1.5f * verticalInput * Time.deltaTime);
        } else {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }

        if (transform.position.y > 0) {
            transform.position = new Vector3(transform.position.x, 0, 0);
        } 
        else if (transform.position.y < -4.45f) {
            transform.position =  new Vector3(transform.position.x, -4.45f, 0);
        }

        if (transform.position.x > 10.36f ) {
            transform.position =  new Vector3(-10.36f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.36f) {
            transform.position =  new Vector3(10.36f, transform.position.y, 0); 
        }
        
    }

    public void DamagePlayerLife() 
    {
        
        if (!isShieldActivate) {
            _lifeHp--;

            if (_lifeHp == 2) {
                _fireEngines[0].SetActive(true);
                AudioSource.PlayClipAtPoint(_hitClip, Camera.main.transform.position);
            } else if (_lifeHp == 1) {
                _fireEngines[1].SetActive(true);
                _audioSources[1].Play();
            }

            _uiManager.UpdateLives(_lifeHp);
            if (_lifeHp < 1) {

                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                

                _gameManager.EndTheGame();

                AudioSource.PlayClipAtPoint(_defeatClip, Camera.main.transform.position);
                Destroy(this.gameObject);

            } 
        } else {
            isShieldActivate = false;
            _shieldGameObject.SetActive(false);
        }
        
    }

    public void TripleShoPowerUpOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedBoostPowerUpOn()
    {
        isSpeedBoostActivate = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    public void EnableShields() {
        isShieldActivate = true;
        _shieldGameObject.SetActive(true);

    }

    public IEnumerator TripleShotPowerDownRoutine() 
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }

    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        isSpeedBoostActivate = false;
    }
}
