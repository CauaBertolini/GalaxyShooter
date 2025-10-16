using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private UIManager _uiManager;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    
    [SerializeField]
    private AudioClip _explosionClip;

    
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
       
        
        if (transform.position.y <= -6.23f) {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.18f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player player = other.GetComponent<Player>();
        Laser laser = other.GetComponent<Laser>();

        if (other.tag == "Player") {

            player.DamagePlayerLife();
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_explosionClip, Camera.main.transform.position);
            Destroy(this.gameObject);

        } else if (other.tag == "Laser") {

            _uiManager.UpdateScore();

            if (other.transform.parent != null) {
                Destroy(other.transform.parent.gameObject);
            }
            
            AudioSource.PlayClipAtPoint(_explosionClip, Camera.main.transform.position);
            Destroy(other.gameObject);

            GameObject explosion = Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2.2f);
            Destroy(this.gameObject);
            
        }
    }

}
