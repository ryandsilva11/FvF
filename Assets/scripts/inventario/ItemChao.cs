using System.Collections;
using UnityEngine;

public class ItemChao : MonoBehaviour
{
    public Item item;
    public GameObject inventarioCtrl;
    public AudioSource oAudioSource;
    public AudioClip collect;

    private bool collected = false;

    private void Start()
    {
        if (oAudioSource == null)
        {
            oAudioSource = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected && collision.CompareTag("Player"))
        {
            collected = true;

            if (oAudioSource != null && collect != null)
            {
                oAudioSource.PlayOneShot(collect);
            }

            if (inventarioCtrl != null)
            {
                Inventario inv = inventarioCtrl.GetComponent<Inventario>();
                if (inv != null)
                {
                    inv.AddItem(item);
                }
            }

            StartCoroutine(Destroyer());
        }
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    } 
}
