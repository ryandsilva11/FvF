using JetBrains.Annotations;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    //metodo que é chamdo quando algo entra no collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            MainPao script = collision.GetComponent<MainPao>();
            if(script != null && script.canBeHit)
            {
                script.GetHit();
            }
        }
    }
}
