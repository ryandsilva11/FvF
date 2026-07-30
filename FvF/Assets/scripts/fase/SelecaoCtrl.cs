using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SelecaoCtrl : MonoBehaviour
{
    public static SelecaoCtrl Instancia;

    public List<GameObject> fases;
    public List<GameObject> iconFase;
    public List<GameObject> cadeados;
    public List<GameObject> caveiras;
    public List<int> fasesBossIndex;

    void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        Progresso.CarregarProgresso();
        IconUpdate();
    }

    void IconUpdate()
    {
        for (int i = 0; i < fases.Count; i++)
        {
            bool desbloqueada = Progresso.fasesDesbloqueadas[i];
            bool isBoss = fasesBossIndex.Contains(i);

            fases[i].SetActive(true);
            iconFase[i].SetActive(true);
            cadeados[i].SetActive(!desbloqueada);
            caveiras[i].SetActive(isBoss);
        }
    }
}
