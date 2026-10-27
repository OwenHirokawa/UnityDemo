using System.Security.Claims;
using UnityEngine;

public class SmallShooter : MonoBehaviour
{
    public float downSpeed = 3;

    public float sidespeed = 2f;
    public float frequency = 2f;

    public GameObject bullet;
    public GameObject explosion;


    public float bulletTimer = 0, bulletWait = 3;

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float newY = transform.position.y - downSpeed * Time.deltaTime;

        float newX = startX + Mathf.Sin(Time.time * frequency) * sidespeed;

        transform.position = new Vector3(newX, newY, transform.position.z);

        bulletTimer += Time.deltaTime;
        if (bulletTimer > bulletWait)
        {
            bulletTimer = 0;
            Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
        }
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                Destroy(collision.gameObject);

            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);
        }
    }

}
