using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float _speed = 3.0f;
    void Start()
    {
        
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
            Destroy(this.gameObject);

        } else if (other.tag == "Laser") {

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
