using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainPlayer : MonoBehaviour
{
    //variaveis publicas
    public Rigidbody2D oRigidbody;
    public float vel;
    public float alturaPulo;
    public SpriteRenderer oSpriteRenderer;
    public Animator anim;
    public Transform rightPe;
    public Transform leftPe;
    public float compriRaio;
    public LayerMask chaoLayer;
    public int life;
    public TextMeshProUGUI lifeText;
    public Collider2D oCollider;
    public Sprite morte;
    public bool canBeHit;
    public bool canRegen;
    public AudioSource oAudioSource;
    public AudioClip jump;
    public AudioClip die;
    public AudioClip damage;
    public AudioClip attack;
    public AudioClip gameStart;

    //variaveis privadas
    private bool isGrounded;
    private bool wasGrounded;
    private float movX;
    public int puloCont;
    private bool died = false;
    private Collider2D[] colliders;

    //método que é chamado assim que o jogo começa
    private void Start()
    {
        oAudioSource.PlayOneShot(gameStart);
        canBeHit = true;
        canRegen = true;
        colliders = gameObject.GetComponents<Collider2D>();
    }

    //metodo que é chamdao frame a frame
    private void Update()
    {
        Move();
        ChaoVerify();
        Pular();
        Atacar();
        lifeText.text = life.ToString();
        if (life <= 0 && !died)
        {
            died = true;
            oSpriteRenderer.sprite = morte;
            anim.enabled = false;
            this.enabled = false;
            Time.timeScale = 0.0f;
            oAudioSource.PlayOneShot(die);
            StartCoroutine(LoadScene());
        }
    }

    //metodo que faz o player andar
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movX = 1;
            anim.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movX = -1;
            anim.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            movX = 0;
            anim.SetBool("isRunning", false);
        }

        oRigidbody.linearVelocity = new Vector2(movX * vel, oRigidbody.linearVelocity.y);

        if (isGrounded && Mathf.Abs(oRigidbody.linearVelocity.x) < 0.05f && movX == 0)
        {
            oRigidbody.linearVelocity = new Vector2(0f, oRigidbody.linearVelocity.y);
        }
    }

    //metodo que faz o player pular
    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Z) && puloCont > 0)
        {
            oAudioSource.PlayOneShot(jump);
            oRigidbody.linearVelocity = new Vector2(oRigidbody.linearVelocity.x, alturaPulo);
            anim.SetBool("isJumping", true);
            puloCont--;
        }
    }

    //metodo que faz o player atacar
    private void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            oAudioSource.PlayOneShot(attack);
            anim.Play("hamb_attack");
        }
    }

    //metodo que verifica se os pés do player encostaram no chão
    private void ChaoVerify()
    {
        bool rightTouch = Physics2D.OverlapCircle(rightPe.position, compriRaio, chaoLayer);
        bool leftTouch = Physics2D.OverlapCircle(leftPe.position, compriRaio, chaoLayer);

        isGrounded = rightTouch || leftTouch;
        if (isGrounded && !wasGrounded)
        {
            puloCont = 2;
            anim.SetBool("isJumping", false);
        }
        Debug.DrawRay(rightPe.position, Vector2.down * compriRaio, Color.red);
        Debug.DrawRay(leftPe.position, Vector2.down * compriRaio, Color.red);

        wasGrounded = isGrounded;
    }

    //método que é executado quando o player toma dano, caso ele possa
    public void GetHit()
    {
        if (!canBeHit) return;

        if(life != 1 && life != 0)
        {
            oAudioSource.PlayOneShot(damage);
        }

        canBeHit = false;
        GetComponentInChildren<Animator>().Play("hamb_damage");
        life--;
        StartCoroutine(ResetDamage());
    }

    //método que é executado quando o player coleta uma vida, caso ele possa
    public void GetRegen()
    {
        if (!canRegen) return;

        canRegen = false;
        life++;
        StartCoroutine(ResetRegen());
    }

    //método que reseta a condição de o player tomar dano depois de meio segundo de algum dano tomado
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canBeHit = true;
    }

    //método que reseta a condição de o player recuperar vida depois de meio segundo de alguma vida coletada
    IEnumerator ResetRegen()
    {
        yield return new WaitForSeconds(0.5f);
        canRegen = true;
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SelecaoFases");
    }
}
