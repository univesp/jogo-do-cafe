using UnityEngine;
using TMPro;

public class Recebimento : MonoBehaviour
{
    [SerializeField] private int caixas;    

    [SerializeField] private Estoque estoque;

    public void AdicionaCaixas(int _quantidade)
    {
        caixas += _quantidade;
    }

    public void EnviaParaEstoque()
    {
        estoque.AdicionaEstoque(caixas);
        caixas = 0;
    }
}
