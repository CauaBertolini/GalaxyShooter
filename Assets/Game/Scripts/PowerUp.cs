using UnityEngine;

public class PowerUp : MonoBehaviour
{
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

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            
            Player player = other.GetComponent<Player>();

            if (player != null) {

                if (_powerUpId == 0) {
                    player.TripleShoPowerUpOn();
                    
                } else if (_powerUpId == 1) {
                    player.SpeedBoostPowerUpOn();
                } 
                else if (_powerUpId == 2) {
                    player.EnableShields();
                }

            }
        
        Destroy(this.gameObject);
            
    } 
           
}
}