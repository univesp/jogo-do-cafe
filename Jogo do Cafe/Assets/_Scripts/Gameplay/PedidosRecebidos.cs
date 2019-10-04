using UnityEngine;
using TMPro;

public class PedidosRecebidos : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private int pedidos = 5;

    [SerializeField] private Estoque estoque;

    //Inteligência Artificial
    [HideInInspector] public int pedidosAI = 0;
    private int semanaContador = 3;
    [HideInInspector] public int ultimoPedidoAI;
    public int[] ultimosTresPedidosAI = new int[3];

    private void Start()
    {
        UIText.text = pedidos.ToString();
    }

    public void AdicionaPedidos(int _quantidade)
    {
        pedidos = _quantidade;
        UIText.text = pedidos.ToString();              
    }

    public void RetiraPedidos()
    {
        ultimosTresPedidosAI[2] = ultimosTresPedidosAI[1];
        ultimosTresPedidosAI[1] = ultimosTresPedidosAI[0];
        ultimosTresPedidosAI[0] = pedidos;
        ultimoPedidoAI = pedidos;
        if (pedidosAI < pedidos)
        {
            pedidosAI = pedidos;
        }
        semanaContador--;
        if (semanaContador == 0)
        {
            semanaContador = 3;
            pedidosAI = pedidos;
        }

        estoque.AtendePedidos(pedidos);
        pedidos = 0;
        UIText.text = pedidos.ToString();
    }

    public void Reinicia()
    {
        pedidos = 5;
        UIText.text = pedidos.ToString();
        pedidosAI = 5;
        semanaContador = 3;
        ultimosTresPedidosAI = new int[3];
        estoque.Reinicia();
    }
}