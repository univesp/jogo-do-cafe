using UnityEngine;
using TMPro;

public class MensagemMovimento : MonoBehaviour
{
    [SerializeField] private GameObject destino;
    private Vector3 posInicial;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject envelope;
    [SerializeField] private TextMeshProUGUI numero;

    [SerializeField] private PedidosColocados pedidosColocados;

    private void Awake()
    {
        posInicial = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = posInicial;
        envelope.SetActive(true);
        numero.gameObject.SetActive(false);
    }

    public void Destino()
    {
        transform.localPosition = destino.transform.localPosition;
        envelope.SetActive(false);
        numero.gameObject.SetActive(true);
        numero.text = pedidosColocados.PegaPedidos().ToString();
    }

    public void Desativa()
    {
        gameObject.SetActive(false);
    }
}
