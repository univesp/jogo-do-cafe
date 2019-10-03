using UnityEngine;

public class Estrada : MonoBehaviour
{
    [SerializeField] private int estradaA = 4, estradaB = 4;

    [SerializeField] private Recebimento recebimento;

    public void RecebeCarga(int _quantidade)
    {
        MoveCargas(_quantidade);
    }

    private void MoveCargas(int _quantidade)
    {
        if (recebimento != null)
        {
            recebimento.AdicionaCaixas(estradaB);
        }
        estradaB = estradaA;
        estradaA = _quantidade;
    }
}