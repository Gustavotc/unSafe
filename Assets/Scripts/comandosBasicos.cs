using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour
{
    private string name;

    public void carregaCena(string nomeCena)
    {
        name = nomeCena;
        StartCoroutine("Abrir");
    }

    private IEnumerator Abrir()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(name);
    }

    public void resetarPontuacoes()
    {
        PlayerPrefs.DeleteAll();
    }

}
