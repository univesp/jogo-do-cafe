using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PedidosColocados : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pedidosTexto;
    [SerializeField] private int pedidos;    

    [SerializeField] private PedidosRecebidos pedidosRecebidos;
    public Animator notificacaoAnimator;

    public bool isPC;

    public Button botaoOK;

    private void Start()
    {
        pedidos = 0;
        pedidosTexto.text = pedidos.ToString();
    }

    //Esse método é usado quando é uma pessoa jogando
    private void DefinePedidos()
    {
        pedidos = int.Parse(pedidosTexto.text);
    }

    //Esse método é usado quando é o computador jogando
    public void DefinePedidos(int _quantidade)
    {
        pedidos = _quantidade;
        //Aparece balão com envelope
        if (pedidos > 0)
        {
            notificacaoAnimator.gameObject.SetActive(true);
        }
    }

    public int PegaPedidos()
    {
        if (!isPC)
        {
            DefinePedidos();
        }
        return pedidos;
    }    

    public void AdicionaPedidos()
    {
        if (pedidos < 99 && botaoOK.interactable)
        {
            pedidos++;
            pedidosTexto.text = pedidos.ToString();
        }
    }

    public void RetiraPedidos()
    {
        if (pedidos > 0 && botaoOK.interactable)
        {
            pedidos--;
            pedidosTexto.text = pedidos.ToString();
        }
    }

    public void PassaParaPedidosRecebidos()
    {
        if (pedidosRecebidos != null)
        {
            if (!isPC)
            {
                DefinePedidos();
            }
            pedidosRecebidos.AdicionaPedidos(pedidos);            
        }
        pedidos = 0;
        pedidosTexto.text = "0";
    }

}
