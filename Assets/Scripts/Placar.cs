using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{
    int ponto;
    Text text;

    private void Start()
    {
        // Pegar Componente Text
        text = GetComponent<Text>();

        ponto = 0;
        // Zera placar na tela
        text.text = ponto.ToString();
    }

    public void somaPonto()
    {
        // Soma ponto
        ponto++;
        // Atualiza placar na tela
        text.text = ponto.ToString();
    }

    public int verificaPonto()
    {
        return ponto;
    }

}
