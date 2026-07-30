using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chave : MonoBehaviour
{
    public int proximaFase;
    public AudioSource oAudioSource;
    public AudioClip nextLevel;
    private MainPlayer player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player = collider.GetComponent<MainPlayer>();
            player.anim.enabled = false;
            player.enabled = false;
            if (proximaFase - 1 < Progresso.fasesDesbloqueadas.Count)
            {
                Progresso.fasesDesbloqueadas[proximaFase - 1] = true;
                PlayerPrefs.SetInt("faseAtual", proximaFase); // salva a fase atual
                PlayerPrefs.Save(); // garante que o dado foi gravado
            }

            Time.timeScale = 0.0f;
            oAudioSource.PlayOneShot(nextLevel);
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SelecaoFases");
    }
}
