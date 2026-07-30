using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Life : MonoBehaviour
{
    public AudioSource oAudioSource;
    public AudioClip collect;

    private void Start()
    {
        if (oAudioSource == null)
        {
            oAudioSource = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainPlayer script = collision.GetComponent<MainPlayer>(); 
            if (script != null && script.canRegen)
            {
                if (oAudioSource != null && collect != null)
                {
                    oAudioSource.PlayOneShot(collect);
                }

                script.GetRegen();
                StartCoroutine(Destroyer());
            }
        }
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
