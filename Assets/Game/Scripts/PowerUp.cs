using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private AudioClip _getShieldPowerUpSound;
    [SerializeField]    
    private AudioClip _getSpeedPowerUpSound;
    [SerializeField]
    private AudioClip _getTrippleShootPowerUpSound;

    
    [SerializeField]
    private int _powerUpId;
    
    [SerializeField]
    private float _speed = 3f;

    void Update()
    {
        if (_powerUpId == 0) {
            _speed = 4;

        } else if (_powerUpId == 2) {
            _speed = 5f;

        } else {
            _speed = 3f;
            
        }
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7) {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            
            Player player = other.GetComponent<Player>();

            if (player != null) {

                if (_powerUpId == 0) {
                    player.TripleShoPowerUpOn();
                    AudioSource.PlayClipAtPoint(_getTrippleShootPowerUpSound, Camera.main.transform.position);
                    
                } else if (_powerUpId == 1) {
                    player.SpeedBoostPowerUpOn();
                    AudioSource.PlayClipAtPoint(_getSpeedPowerUpSound, Camera.main.transform.position);
                } 
                else if (_powerUpId == 2) {
                    player.EnableShields();
                    AudioSource.PlayClipAtPoint(_getShieldPowerUpSound, Camera.main.transform.position);
                }

            }
        
        Destroy(this.gameObject);
            
    } 
           
}
}