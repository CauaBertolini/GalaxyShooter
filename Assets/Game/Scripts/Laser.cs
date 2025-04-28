using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 15.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); 

         if (transform.position.y >= 6f) {
            Destroy(this.gameObject);
            Debug.Log("Laser destrúido!");
        } 

    }
}