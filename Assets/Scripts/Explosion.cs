using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem electricParticles;
    public AudioSource explosionSound;

    void Start()
    {
        electricParticles.Play();
        //explosionSound.Play();

        Destroy(gameObject, 1f);
    }
}
