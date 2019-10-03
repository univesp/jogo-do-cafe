using UnityEngine;

public class InteligenciaArtificial : MonoBehaviour
{
    private int resultado;

    public void CalculoMedio(Setor _setor)
    {
        resultado = (_setor.pedidosRecebidos.ultimoPedidoAI + (Random.Range(2, 20) - _setor.estoque.caixasAI + (_setor.pedidosRecebidos.ultimoPedidoAI * 2) - ((_setor.pedidosRecebidos.ultimosTresPedidosAI[2] + _setor.pedidosRecebidos.ultimosTresPedidosAI[1] + _setor.pedidosRecebidos.ultimosTresPedidosAI[0])/3)) / 9) + Random.Range(-4, 4);        
        if (resultado > 0)
        {
            _setor.pedidosColocados.DefinePedidos(resultado);
        }
    }
}
