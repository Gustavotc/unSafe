using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{

    private int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public string[] perguntas;      //Armazena todas as perguntas 
    public string[] alternativaA;   //Armazena todas as Alternativas A
    public string[] alternativaB;   //Armazena todas as Alternativas B
    public string[] alternativaC;   //Armazena todas as Alternativas C
    public string[] alternativaD;   //Armazena todas as Alternativas D
    public string[] corretas;       //Armazena as alternativas corretas

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;


    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas."; 
    }

    public void resposta(string alternativa)
    {
        switch(alternativa)
        {
            case "A": {
                    if(alternativaA[idPergunta] == corretas[idPergunta])
                    {
                        acertos += 1;
                    }
                    break;
                }
            case "B":
                {
                    if (alternativaB[idPergunta] == corretas[idPergunta])
                    {
                        acertos += 1;
                    }
                    break;
                }
            case "C":
                {
                    if (alternativaC[idPergunta] == corretas[idPergunta])
                    {
                        acertos += 1;
                    }
                    break;
                }
            case "D":
                {
                    if (alternativaD[idPergunta] == corretas[idPergunta])
                    {
                        acertos += 1;
                    }
                    break;
                }
        }

        proximaPergunta();
    }

    void proximaPergunta()
    {
        idPergunta += 1;

        if(idPergunta <= (questoes-1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
        }
        else
        {
            media = 10 * (acertos / questoes); //calcula a média com base no % de acertos
            notaFinal = Mathf.RoundToInt(media); //arredonda a nota para próximo int

            if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString() ))
            {
                PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);

            SceneManager.LoadScene("notaFinal");
        }
    }
}
