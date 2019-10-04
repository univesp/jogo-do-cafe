using UnityEngine;
using TMPro;

public class Estoque : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private int caixas = 12;
    [SerializeField] private int caixasParaBacklog;

    [SerializeField] private Custo custo;
    [SerializeField] private Backlog backlog;
    [SerializeField] private Expedicao expedicao;

    //Inteligência Artificial
    [HideInInspector] public int caixasAI = 0;

    [SerializeField] private GameObject aumentaAnimacao;
    [SerializeField] private GameObject diminuiAnimacao;

    private void Start()
    {
        UIText.text = caixas.ToString();
    }

    public void AdicionaEstoque(int _quantidade)
    {
        caixas += _quantidade;
        UIText.text = caixas.ToString();
        aumentaAnimacao.SetActive(true);
    }

    public void AtendePedidos(int _pedidos)
    {
        if(backlog.PegaPendencias() > 0)
        {            
            if (backlog.PegaPendencias() >= caixas)
            {
                backlog.RetiraPendencias(caixas);
                caixas = 0;
            }
            else
            {
                caixasParaBacklog = caixas;
                caixas -= backlog.PegaPendencias();
                backlog.RetiraPendencias(caixasParaBacklog - caixas);                
            }
        }

        if (_pedidos > caixas)
        {
            EnviaBacklog(_pedidos - caixas);
            EnviaExpedicao(caixas);
        }
        else
        {
            EnviaExpedicao(_pedidos);
        }

        if(caixas != 0)
        {
            diminuiAnimacao.SetActive(true);
        }
    }

    public void ContaCusto()
    {
        custo.AdicionaGastos(caixas);
    }

    private void EnviaBacklog(int _sobras)
    {
        backlog.AdicionaPendencias(_sobras);
    }

    private void EnviaExpedicao(int _atendidos)
    {
        expedicao.AdicionaExpedicao(_atendidos);
        caixas -= _atendidos;
        UIText.text = caixas.ToString();

        caixasAI = caixas;
    }

    public void Reinicia()
    {
        caixas = 12;
        UIText.text = caixas.ToString();
        caixasAI = 0;
        expedicao.Reinicia();
    }
}