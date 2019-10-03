using UnityEngine;
using TMPro;

public class Custo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    [HideInInspector] public int gastos = 0;

    [SerializeField] private GameObject aumentaAnimacao;

    private void Start()
    {
        UIText.text = gastos.ToString();
    }

    public void AdicionaGastos(int _quantidade)
    {
        gastos += _quantidade;
        UIText.text = gastos.ToString();
        aumentaAnimacao.SetActive(true);
    }
}