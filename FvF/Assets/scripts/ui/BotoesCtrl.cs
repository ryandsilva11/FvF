using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesCtrl : MonoBehaviour
{

    //variáveis públicas
    public List<Button> botoes;
    public GameObject panelOpcoes;
    public GameObject panelCreditos;
    public Image imgBrilho;
    public TextMeshProUGUI txtBrilho;
    public TextMeshProUGUI txtSom;
    public AudioMixer audioMixer;
    public Inventario inventario;

    //variáveis privadas
    private int brilho;
    private int incBrilho = 10; // valor fixo para incrementar/decrementar
    private int som;
    private int incSom = 10;

    private void Start()
    {
        brilho = PlayerPrefs.GetInt("brilho", 100);
        som = PlayerPrefs.GetInt("som", 100);
        AtualizaBrilho();
        AtualizaSom();

        // Configurar os listeners dos botões
        foreach (Button bt in botoes)
        {
            if (bt == null) continue;

            switch (bt.name)
            {
                case "BtJogar":
                    bt.onClick.AddListener(() => TrocaCena("SelecaoFases"));
                    break;
                case "BtOpcoes":
                    bt.onClick.AddListener(() => panelOpcoes.SetActive(true));
                    break;
                case "BtSair":
                    bt.onClick.AddListener(() => Application.Quit());
                    break;
                case "MaisSom":
                    bt.onClick.AddListener(AumentaSom);
                    break;
                case "MaisBrilho":
                    bt.onClick.AddListener(AumentaBrilho);
                    break;
                case "MenosSom":
                    bt.onClick.AddListener(DiminuiSom);
                    break;
                case "MenosBrilho":
                    bt.onClick.AddListener(DiminuiBrilho);
                    break;
                case "BtCreditos":
                    bt.onClick.AddListener(() => panelCreditos.SetActive(true));
                    break;
                case "BtMenu":
                    bt.onClick.AddListener(() => panelOpcoes.SetActive(false));
                    break;
                case "BtMenu2":
                    bt.onClick.AddListener(() => panelCreditos.SetActive(false));
                    break;
                case "BtMenu3":
                case "BtMenu4":
                    bt.onClick.AddListener(() => TrocaCena("MenuPrincipal"));
                    break;
                case "BtJogo":
                    bt.onClick.AddListener(() => inventario.FecharInventario());
                    break;
            }
        }
    }

    private void TrocaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    private void AumentaBrilho()
    {
        brilho += incBrilho;
        brilho = Mathf.Clamp(brilho, 1, 100);
        AtualizaBrilho();
        PlayerPrefs.SetInt("brilho", brilho);
        PlayerPrefs.Save();
    }

    private void DiminuiBrilho()
    {
        brilho -= incBrilho;
        brilho = Mathf.Clamp(brilho, 1, 100);
        AtualizaBrilho();
        PlayerPrefs.SetInt("brilho", brilho);
        PlayerPrefs.Save();
    }

    private void AtualizaBrilho()
    {
        if (imgBrilho == null || txtBrilho == null) return;

        Color cor = imgBrilho.color;
        cor.a = 1f - (float)brilho / 100f;
        imgBrilho.color = cor;
        txtBrilho.text = brilho + "%";
    }

    private void AumentaSom()
    {
        som += incSom;
        som = Mathf.Clamp(som, 1, 100);
        AtualizaSom();
        PlayerPrefs.SetInt("som", som);
        PlayerPrefs.Save();
    }

    private void DiminuiSom()
    {
        som -= incSom;
        som = Mathf.Clamp(som, 1, 100);
        AtualizaSom();
        PlayerPrefs.SetInt("som", som);
        PlayerPrefs.Save();
    }

    private void AtualizaSom()
    {
        if (txtSom == null || audioMixer == null) return;

        float volumeDb = (som == 0) ? -80f : Mathf.Log10(som / 100f) * 20f;
        audioMixer.SetFloat("MasterVolume", volumeDb);
        txtSom.text = som + "%";
    }
}
