using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{

    public bool canTripleShoot = false;
    public bool isSpeedBoostActivate = false; 

    public bool isShieldActivate = false;
    public int _lifeHp = 3;
    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _trippleShootPrefab;
    
    [SerializeField]    
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 7f;
    void Start()
    {
        Debug.Log("X pos: " + transform.position.x + " Y pos: " + transform.position.y + " Z pos: " + transform.position);
        Debug.Log("Player iniciado");
        transform.position = new Vector3(0, 0, 0);
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
            if (_lifeHp < 1) {
            Destroy(this.gameObject);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        } else {
            isShieldActivate = false;
        }
        
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
