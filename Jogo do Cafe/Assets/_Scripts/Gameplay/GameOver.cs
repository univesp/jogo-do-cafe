using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioClip musica;

    [SerializeField] private Custo fabricaCustos;
    [SerializeField] private Custo distribuidorCustos;
    [SerializeField] private Custo atacadistaCustos;
    [SerializeField] private Custo varejistaCustos;

    [SerializeField] private UnityEvent vitoriaAcao;
    [SerializeField] private UnityEvent derrotaAcao;

    [SerializeField] private TextMeshProUGUI fabricaTexto;
    [SerializeField] private TextMeshProUGUI distribuidorTexto;
    [SerializeField] private TextMeshProUGUI atacadistaTexto;
    [SerializeField] private TextMeshProUGUI varejistaTexto;

    private void OnEnable()
    {
        AudioPlayer.instance.PlayBGM(musica);

        fabricaTexto.text = fabricaCustos.gastos.ToString();
        distribuidorTexto.text = distribuidorCustos.gastos.ToString();
        atacadistaTexto.text = distribuidorCustos.gastos.ToString();
        varejistaTexto.text = varejistaCustos.gastos.ToString();

        if(distribuidorCustos.gastos < fabricaCustos.gastos && distribuidorCustos.gastos < atacadistaCustos.gastos && distribuidorCustos.gastos < varejistaCustos.gastos)
        {
            vitoriaAcao.Invoke();
        }
        else
        {
            derrotaAcao.Invoke();
        }
    }
}
