using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FaseClique : MonoBehaviour, IPointerClickHandler
{
    public int indiceFase;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Progresso.fasesDesbloqueadas[indiceFase])
        {
            SceneManager.LoadScene("Fase" + (indiceFase + 1));
        }
    }
}
