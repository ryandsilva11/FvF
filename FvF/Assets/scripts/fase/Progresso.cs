using System.Collections.Generic;
using UnityEngine;

public static class Progresso
{
    public static List<bool> fasesDesbloqueadas = new List<bool> { true, false, false, false, false };

    public static void CarregarProgresso()
    {
        int faseAtual = PlayerPrefs.GetInt("faseAtual", 1); // pega o salvo ou padrão 1

        // Atualiza lista para desbloquear até a fase atual
        for (int i = 0; i < fasesDesbloqueadas.Count; i++)
        {
            fasesDesbloqueadas[i] = (i < faseAtual);
        }
    }
}
