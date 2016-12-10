using UnityEngine;
using System.Collections;

public class AsteroidHealth : MonoBehaviour {

    public int health = 10;
    public AudioClip deathClip;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;
    public GameObject zombie;

    AudioSource enemyAudio;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int damage)
    {
        if (enemyAudio != null)
        {
            enemyAudio.Play();
        }

    }

}
