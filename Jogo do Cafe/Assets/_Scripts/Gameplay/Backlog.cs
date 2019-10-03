using UnityEngine;
using TMPro;

public class Backlog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private int pendencias;
    [SerializeField] private int pendenciasAtendidas;

    [SerializeField] private Expedicao expedicao;
    [SerializeField] private Custo custo;

    [SerializeField] private GameObject aumentaAnimacao;
    [SerializeField] private GameObject diminuiAnimacao;

    public int testeBacklog = 0;

    private void Start()
    {
        pendencias = 0;
        UIText.text = pendencias.ToString();
    }

    public int PegaPendencias()
    {
        return pendencias;
    }

    public void AdicionaPendencias(int _quantidade)
    {
        testeBacklog += _quantidade;
        pendencias += _quantidade;
        UIText.text = pendencias.ToString();
        aumentaAnimacao.SetActive(true);
    }

    public void RetiraPendencias(int _quantidade)
    {
        pendenciasAtendidas = pendencias;
        pendencias -= _quantidade;
        UIText.text = pendencias.ToString();
        pendenciasAtendidas -= pendencias;
        expedicao.AdicionaExpedicao(pendenciasAtendidas);
        diminuiAnimacao.SetActive(true);
    }

    public void CobraPendencias()
    {
        custo.AdicionaGastos(pendencias * 2);
    }
}
