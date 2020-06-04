using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
        audioSource.PlayOneShot(enemyDamageSFX); // play SFX
        print("Current hitpoints: " + hitPoints);
    }

    void KillEnemy()
    {
        // important to instantiate before destroying this object
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(vfx.gameObject, vfx.main.duration);
    }
}
