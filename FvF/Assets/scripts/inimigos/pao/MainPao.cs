using System.Collections;
using UnityEngine;

public class MainPao : MonoBehaviour
{
    //variaveis publicas
    public int life;
    public float vel;
    public Transform pontoA;
    public Transform pontoB;
    public Rigidbody2D oRigidbody;
    public Animator anim;
    public Collider2D oCollider;
    public SpriteRenderer oSpriteRenderer;
    public bool isAttacking;
    public bool canBeHit;
    public AudioSource oAudioSource;
    public AudioClip damage;

    //variaveis privadas
    private bool goRight;

    //método que é chamado assim que o jogo começa
    private void Start()
    {
        canBeHit = true;
    }

    //metodo que é chamado a cada 0,02 segundos
    private void FixedUpdate()
    {
        Movimento();
    }

    //metodo que executa a IAzinha do movimento e ataque do inimigo
    private void Movimento()
    {
        if (isAttacking)
        {
            oRigidbody.linearVelocity = Vector2.zero;
            return; 
        }

        if (goRight)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, pontoB.position, vel * Time.fixedDeltaTime);
            if (Vector2.Distance(transform.position, pontoB.position) < 0.5f)
            {
                goRight = false;
            }
        }

        else
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, pontoA.position, vel * Time.fixedDeltaTime);
            if (Vector2.Distance(transform.position, pontoA.position) < 0.5f)
            {
                goRight = true;
            }
        }
    }

    //método que faz a lógica para o pão tomar dano com cooldown
    public void GetHit()
    {
        if (!canBeHit) return;

        oAudioSource.PlayOneShot(damage);
        if (life <= 0)
        {
            this.enabled = false;
            anim.enabled = false;
            oSpriteRenderer.enabled = false;
            oRigidbody.linearVelocity = Vector2.zero;
            oCollider.enabled = false;
            StartCoroutine(Destroyer());
        }

        GetComponentInChildren<Animator>().Play("pao_damage");
        canBeHit = false;
        life--;
        StartCoroutine(ResetDamage());
    }

    //método que espera meio segundo para que o pão possa ser danificado novamente
    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canBeHit = true;
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
