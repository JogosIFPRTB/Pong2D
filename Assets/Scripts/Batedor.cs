using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batedor : MonoBehaviour
{
    public bool jogador1;

    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float altura;    

    private void Start()
    {
        // Pegar altura do objeto
        altura = transform.localScale.y;

        // Pegar posições da tela, limites, transformando a visão da camera
        Bola.emBaixoEsquerda = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Bola.emCimaDireita = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        float movimento;

        // Define controle e velocidade do batedor
        if (jogador1)
        {
            movimento = Input.GetAxis("Vertical") 
                        * velocidade
                        * Time.deltaTime;
        }
        else
        {
            movimento = Input.GetAxis("Vertical2")
                        * velocidade
                        * Time.deltaTime;
        }

        Vector2 posicao = transform.position;

        // Limita batedor em baixo
        if (posicao.y < Bola.emBaixoEsquerda.y + altura / 2
              && movimento < 0)
            movimento = 0;

        // Limita batedor em cima
        if (posicao.y > Bola.emCimaDireita.y - altura / 2
                 && movimento > 0)
            movimento = 0;

        // Movimenta o batedor
        transform.Translate(movimento * Vector2.up); //(0,1,0)
    }
}
