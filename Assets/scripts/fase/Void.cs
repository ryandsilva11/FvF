using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainPlayer player = collision.GetComponent<MainPlayer>();
            player.oSpriteRenderer.sprite = player.morte;
            player.life = 0;
        }
    }
}
