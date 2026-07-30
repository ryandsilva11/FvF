using UnityEngine;

public class DetecaoPao : MonoBehaviour
{

    //variaveis publicas
    public Animator anim;
    public MainPao pao;

    //metodo que é chamado quando algo fica dentro do collider
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pao.isAttacking = true;
            anim.SetBool("isAttacking", true);
        }
    }

    //metodo que é chamado quando algo sai do collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isAttacking", false);
            pao.isAttacking = false;
        }
    }
}
