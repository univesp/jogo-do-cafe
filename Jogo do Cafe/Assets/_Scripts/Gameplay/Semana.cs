using UnityEngine;
using TMPro;

public class Semana : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private TextMeshProUGUI proximaSemana;
    [SerializeField] private TextMeshProUGUI semanaAtual;

    public void TrocaSemana(int _semana)
    {
        proximaSemana.text = "SEMANA " + _semana.ToString("00");
        semanaAtual.text = "SEMANA " + (_semana - 1).ToString("00");
        animator.Play("SemanaTroca");
    }

    public void ReiniciaAnimacao()
    {
        semanaAtual.text = proximaSemana.text;        
    }
}