using System.Collections;
using UnityEngine;

public class ItemChao : MonoBehaviour
{
    //variáveis públicas
    public Item item;
    public GameObject inventarioCtrl;
    public AudioSource oAudioSource;
    public AudioClip collect;

    //variáveis privadas
    private bool collected = false;

    //método que é chamado quando algo colide com o collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected && collision.CompareTag("Player"))
        {
            collected = true;
            oAudioSource.PlayOneShot(collect);
            StartCoroutine(Destroyer());
            inventarioCtrl.GetComponent<Inventario>().AddItem(item);
        }
    }


    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    } 

}
