using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private GameObject hole;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public static event Action<Collider> FinishHole;
            
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FinishHole?.Invoke(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var impactStrength = collision.relativeVelocity.magnitude;

        if (!(impactStrength > 1f)) return;
        if (audioSource == null) return;
        
        audioSource.volume = Mathf.Clamp01(impactStrength / 10f);
        audioSource.pitch = Random.Range(0.95f, 1.05f) * (1f + impactStrength / 20f);
        StartCoroutine(PlaySfxPart(audioSource, audioClip, 1.2f, 1.5f));
    }

    private IEnumerator PlaySfxPart(AudioSource source, AudioClip clip, float startTime, float endTime)
    {
        source.clip = clip;
        source.time = startTime;
        source.PlayOneShot(clip);

        while (source.isPlaying && source.time < endTime)
        {
            yield return null;
        }

        source.Stop();
    }
}
