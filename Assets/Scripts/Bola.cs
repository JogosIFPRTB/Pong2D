using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public float velocidade;
    public Vector2 direcao;
    float raio;

    public Placar placarEsquerda;
    public Placar placarDireita;
    public int pontuacaoFinal;

    public static Vector2 emBaixoEsquerda;
    public static Vector2 emCimaDireita;

    void Start()
    {
        // Pega dimensão do raio da bola
        raio = transform.localScale.x / 2;

        DirecaoAleatoria();        

        // Pegar posições da tela, limites, transformando a visão da camera
        emBaixoEsquerda = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        emCimaDireita = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        Vector2 posicao = transform.position;

        if (posicao.x < emBaixoEsquerda.x + raio)
        {
            Debug.Log("Ponto da Direita");
            VerificaVitoria(placarDireita);
        }
        if (posicao.x > emCimaDireita.x - raio)
        {
            Debug.Log("Ponto da Esuqerda");
            VerificaVitoria(placarEsquerda);
        }
    }

    void VerificaVitoria(Placar placar)
    {
        placar.somaPonto();

        if (placar.verificaPonto() == pontuacaoFinal)
        {
            // Zera o tempo do jogo
            Time.timeScale = 0;
            // Desabilita o script
            enabled = false;
        }
        else
        {
            // Reseta posição;
            transform.position = Vector2.zero;
            DirecaoAleatoria();
        }            
    }

    void DirecaoAleatoria()
    {
        // Gera um Vector2 aletorio (1,1) (-1,1) (1,-1) (-1,-1)
        direcao = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1,
                              Random.Range(0, 2) == 0 ? -1 : 1);

        // Movimenta bola
        GetComponent<Rigidbody2D>().velocity = direcao *
                                               velocidade;
    }
}
