using UnityEngine;
using System.Collections;

public class AsteroidHealth : MonoBehaviour {

    public int health = 3;
    public AudioClip deathClip;
    public GameObject explosionPrefab;
    int randomAsteroid;
    public GameObject[] asteroidPrefabs;
    GameObject newAstroid;
    Quaternion randomRotation;
    Vector2 randomPosition;
    int numberOfAstroids;
    

    public void TakeDamage(int damage)
    {
        health = -damage;

        if (health <= 0)
        {
            destroyAstroid();
        }

    }

    void destroyAstroid()
    {
        numberOfAstroids = Mathf.RoundToInt(Random.Range(0.49f, 5.49f));
        if (numberOfAstroids == 1)
        {
            randomPosition = new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f));
            randomRotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z + Random.Range(-0f, 360f));
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);
        }
        else if (numberOfAstroids == 2)
        {
            randomPosition = new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f));
            randomRotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z + Random.Range(-0f, 140f));
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);
            randomPosition = new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f));
            randomRotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z + Random.Range(170f, 320f));
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);
        }
        else if (numberOfAstroids == 3)
        {

            randomPosition = new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f));
            randomRotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z + Random.Range(-0f, 110f));
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);
            randomPosition = new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f));
            randomRotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z + Random.Range(125f, 235f));
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);
            randomPosition = new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f));
            randomRotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z + Random.Range(-250f, 350f));
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);
        }
        Destroy(gameObject);
    }

}
