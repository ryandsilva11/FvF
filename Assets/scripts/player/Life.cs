using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Life : MonoBehaviour
{
    //variáveis públicas
    public AudioSource oAudioSource;
    public AudioClip collect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainPlayer script = collision.GetComponent<MainPlayer>(); 
            if(script != null && script.canRegen)
            {
                oAudioSource.PlayOneShot(collect);
                StartCoroutine(Destroyer());
                script.GetRegen();
            }
        }
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
