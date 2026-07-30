using UnityEngine;

public class AttackPao : MonoBehaviour
{

    //método que é chamado quando algo collide com o collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainPlayer script = collision.GetComponent<MainPlayer>();
            if (script != null && script.canBeHit)
            {
                script.GetHit();
            }
        }
    }
}
