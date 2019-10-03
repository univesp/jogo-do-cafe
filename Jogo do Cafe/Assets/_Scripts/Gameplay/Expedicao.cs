using UnityEngine;
using TMPro;

public class Expedicao : MonoBehaviour
{
    [SerializeField] private int caixas;

    [SerializeField] private Estrada estrada;

    [SerializeField] private GameObject transportePai;
    [SerializeField] private Transporte transporte;

    public void AdicionaExpedicao(int _quantidade)
    {
        caixas += _quantidade;
        if(transporte == null && caixas > 0)
        {
            transporte = transportePai.transform.GetChild(0).GetComponent<Transporte>();
            transporte.gameObject.SetActive(true);
        }
        if (transporte != null)
        {
            transporte.cargaTexto.text = caixas.ToString();
        }
    }

    public void EnviaEstrada()
    {
        transporte = null;
        estrada.RecebeCarga(caixas);
        caixas = 0;   
    }

    public string GetCaixas()
    {
        return caixas.ToString();
    }
}