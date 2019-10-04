using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Tutorial : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip tutorialClip;
    [SerializeField] private AudioClip semanaClip;

    [SerializeField] private RectTransform evidencia1;
    [SerializeField] private RectTransform evidencia2;

    [SerializeField] private Image tutoriaAreaClique;
    [SerializeField] private RectTransform tutorialJanela;
    [SerializeField] private TextMeshProUGUI tutorialTextmesh;
    [SerializeField] string[] tutorialTexto;
    [SerializeField] private int index;
    [SerializeField] private ScrollRect scroll;

    private bool podeContinuar;

    [SerializeField] private TransicaoDeTela transicao;

    //Variáveis da rodada exemplo
    [SerializeField] private Setor fabrica;
    [SerializeField] private Setor distribuidor;
    [SerializeField] private Setor atacadista;
    [SerializeField] private Setor varejista;

    [SerializeField] private Estrada estradaFabrica;
    [SerializeField] private int fornecedorDaFabrica;

    [SerializeField] Semana semanaCont;
    private int semana = 1;

    private int playersPlayed = 0;

    //Estou declarando aqui para melhorar a performance do jogo
    private WaitForSeconds highWaitTime = new WaitForSeconds(2.0f);
    private WaitForSeconds lowWaitTime = new WaitForSeconds(1.0f);

    [SerializeField] private InteligenciaArtificial IA;

    public bool voltando;

    private bool jaAndou;
    private void Start()
    {
        tutorialJanela.gameObject.SetActive(true);
        index = -1;
        podeContinuar = true;
        ProximoTutorial();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ProximoTutorial();
    }

    public void ProximoTutorial()
    {        
        if (podeContinuar)
        {
            index++;
            AudioPlayer.instance.PlaySFX(tutorialClip);
            scroll.verticalNormalizedPosition = 1.0f;
            switch (index)
            {
                case 3:
                    evidencia1.gameObject.SetActive(true);
                    evidencia1.sizeDelta = new Vector2(391.0f, 263.4f);
                    evidencia1.localPosition = new Vector2(203.0f, 80.0f);

                    tutorialJanela.localPosition = new Vector2(111.0f, -183.0f);
                    voltando = false;
                    break;

                case 4:
                    evidencia1.sizeDelta = new Vector2(279.2f, 263.4f);
                    evidencia1.localPosition = new Vector2(352.1f, -23.0f);

                    tutorialJanela.localPosition = new Vector2(-138.0f, 71.0f);
                    voltando = false;
                    break;

                case 5:
                    evidencia1.sizeDelta = new Vector2(326.1f, 263.4f);
                    evidencia1.localPosition = new Vector2(55.6f, -183.0f);

                    tutorialJanela.localPosition = new Vector2(0.0f, 47.7f);
                    voltando = false;
                    break;

                case 6:
                    evidencia1.sizeDelta = new Vector2(253.0f, 263.4f);
                    evidencia1.localPosition = new Vector2(-513.5f, 34.0f);

                    tutorialJanela.localPosition = new Vector2(89.0f, 34.0f);
                    voltando = false;
                    break;

                case 7:
                    evidencia1.sizeDelta = new Vector2(384.0f, 263.4f);
                    evidencia1.localPosition = new Vector2(-107.3f, 215.0f);

                    tutorialJanela.localPosition = new Vector2(37.7f, -60.0f);
                    voltando = false;
                    break;

                case 10:
                    //Reinicia as operações do índice 11
                    fabrica.pedidosRecebidos.Reinicia();
                    distribuidor.pedidosRecebidos.Reinicia();
                    atacadista.pedidosRecebidos.Reinicia();
                    varejista.pedidosRecebidos.Reinicia();

                    evidencia1.gameObject.SetActive(false);
                    evidencia2.gameObject.SetActive(false);

                    tutorialJanela.transform.localPosition = Vector3.zero;
                    voltando = false;
                    break;

                case 11:
                    evidencia1.gameObject.SetActive(true);
                    evidencia2.gameObject.SetActive(true);

                    evidencia1.sizeDelta = new Vector2(250.4f, 111.4f);
                    evidencia1.localPosition = new Vector2(-558.1f, -317.0f);

                    evidencia2.sizeDelta = new Vector2(290.9f, 274.1f);
                    evidencia2.localPosition = new Vector2(-301.3f, 14.6f);

                    tutorialJanela.localPosition = new Vector2(222.0f, 0.0f);
                    if (!voltando)
                    {
                        fabrica.pedidosRecebidos.RetiraPedidos();
                        distribuidor.pedidosRecebidos.RetiraPedidos();
                        atacadista.pedidosRecebidos.RetiraPedidos();
                        varejista.pedidosRecebidos.RetiraPedidos();
                    }
                    voltando = false;
                    break;

                case 12:
                    evidencia2.gameObject.SetActive(false);

                    evidencia1.localPosition = new Vector2(-414.0f, -255.0f);

                    tutorialJanela.localPosition = new Vector2(134.0f, -147.0f);
                    voltando = false;
                    break;

                case 13:
                    voltando = false;
                    break;

                case 14:
                    //Reinicia as operações do indice 15
                    if (voltando)
                    {
                        fabrica.custo.Reinicia();
                        distribuidor.custo.Reinicia();
                        atacadista.custo.Reinicia();
                        varejista.custo.Reinicia();
                    }
                    evidencia2.gameObject.SetActive(false);

                    evidencia1.localPosition = new Vector2(-414.0f, -255.0f);

                    tutorialJanela.localPosition = new Vector2(134.0f, -147.0f);
                    voltando = false;
                    break;

                case 15:
                    evidencia1.localPosition = new Vector2(-414.0f, -319.0f);

                    if (!voltando)
                    {
                        fabrica.estoque.ContaCusto();
                        distribuidor.estoque.ContaCusto();
                        atacadista.estoque.ContaCusto();
                        varejista.estoque.ContaCusto();
                    }
                    voltando = false;
                    break;

                case 18:
                    //Reincia as operações do índice 19
                    if (voltando)
                    {
                        fabrica.pedidosColocados.Reinicia();
                        distribuidor.pedidosColocados.Reinicia();
                        atacadista.pedidosColocados.Reinicia();
                        varejista.pedidosColocados.Reinicia();
                        distribuidor.pedidosColocados.botaoOK.interactable = false;
                        fabrica.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                        atacadista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                        varejista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                    }
                    tutoriaAreaClique.raycastTarget = true;

                    evidencia1.gameObject.SetActive(false);
                    evidencia2.gameObject.SetActive(false);

                    tutorialJanela.transform.localPosition = Vector3.zero;
                    voltando = false;
                    break;

                case 19:
                    distribuidor.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                    evidencia1.sizeDelta = new Vector2(391.7f, 111.4f);
                    evidencia1.localPosition = new Vector2(-486.7f, -190.3f);                    
                    
                    IA.CalculoMedio(fabrica);
                    IA.CalculoMedio(atacadista);
                    IA.CalculoMedio(varejista);

                    distribuidor.pedidosColocados.botaoOK.interactable = true;                    
                    tutoriaAreaClique.raycastTarget = false;

                    fabrica.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                    atacadista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                    varejista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                    voltando = false;
                    break;

                case 20:
                    distribuidor.pedidosColocados.botaoOK.interactable = false;
                    distribuidor.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                    tutoriaAreaClique.raycastTarget = true;
                    voltando = false;
                    break;

                case 21:
                    //Reinicia as operações do índice 22
                    if (voltando)
                    {
                        tutoriaAreaClique.raycastTarget = true;
                        evidencia1.sizeDelta = new Vector2(391.7f, 111.4f);
                        evidencia1.localPosition = new Vector2(-486.7f, -190.3f);
                        podeContinuar = true;
                        tutorialJanela.transform.localPosition = Vector3.zero;
                        semanaCont.Reinicia();
                        semana = 1;

                        fabrica.pedidosRecebidos.Reinicia();
                        distribuidor.pedidosRecebidos.Reinicia();
                        atacadista.pedidosRecebidos.Reinicia();
                        varejista.pedidosRecebidos.Reinicia();

                        fabrica.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                        atacadista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                        varejista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);
                        distribuidor.pedidosColocados.notificacaoAnimator.gameObject.SetActive(false);

                        fabrica.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                        atacadista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                        varejista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                        distribuidor.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                    }
                    voltando = false;

                    break;

                case 22:
                    //Reinicia operações do índice 23                                        
                    if (voltando)
                    {
                        fabrica.expedicao.Reinicia();
                        distribuidor.expedicao.Reinicia();
                        atacadista.expedicao.Reinicia();
                        varejista.expedicao.Reinicia();

                        fabrica.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                        atacadista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                        varejista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                        distribuidor.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);


                    }
                    StartCoroutine(QuintaAcao());
                    break;

                case 23:
                    evidencia1.gameObject.SetActive(false);
                    tutorialJanela.localPosition = new Vector2(302.0f, 195.4f);
                    if (!jaAndou)
                    {
                        jaAndou = true;
                        EventManager.CallAction();
                        estradaFabrica.RecebeCarga(fornecedorDaFabrica);
                        fabrica.expedicao.EnviaEstrada();
                        distribuidor.expedicao.EnviaEstrada();
                        atacadista.expedicao.EnviaEstrada();
                        varejista.expedicao.EnviaEstrada();
                    }
                    voltando = false;
                    break;

                case 24:
                    //Reinicia as operações do índice 25
                    evidencia1.gameObject.SetActive(false);
                    tutorialJanela.localPosition = new Vector2(302.0f, 195.4f);
                    voltando = false;
                    break;

                case 25:
                    evidencia1.gameObject.SetActive(true);

                    evidencia1.sizeDelta = new Vector2(250.4f, 111.4f);
                    evidencia1.localPosition = new Vector2(-558.1f, -317.0f);

                    fabrica.recebimento.EnviaParaEstoque();
                    distribuidor.recebimento.EnviaParaEstoque();
                    atacadista.recebimento.EnviaParaEstoque();
                    varejista.recebimento.EnviaParaEstoque();

                    voltando = false;
                    break;

                case 27:
                    evidencia1.gameObject.SetActive(true);

                    evidencia1.sizeDelta = new Vector2(404.6f, 90.9f);
                    evidencia1.localPosition = new Vector2(-489.2f, -136.0f);
                    voltando = false;
                    break;
                
                case 28:
                    evidencia1.gameObject.SetActive(true);
                    evidencia2.gameObject.SetActive(true);

                    evidencia1.sizeDelta = new Vector2(129.6f, 289.7f);
                    evidencia1.localPosition = new Vector2(-593.5f, -253.8f);

                    evidencia2.sizeDelta = new Vector2(132.4f, 218.8f);
                    evidencia2.localPosition = new Vector2(-447.6f, -284.0f);
                    voltando = false;
                    break;

                case 29:
                    evidencia1.gameObject.SetActive(false);
                    evidencia2.gameObject.SetActive(false);
                    voltando = false;
                    break;

                case 30:                    
                    podeContinuar = false;
                    transicao.ChamaTransicao(10.0f);
                    voltando = false;
                    break;                                    

                default:
                    evidencia1.gameObject.SetActive(false);
                    evidencia2.gameObject.SetActive(false);

                    tutorialJanela.transform.localPosition = Vector3.zero;
                    voltando = false;
                    break;
            }
            if (index != 30)
            {
                tutorialTextmesh.text = tutorialTexto[index];
            }
        }
    }

    public void VoltaTutorial()
    {
        if (index > 0)
        {
            index -= 2;
            voltando = true;
            StopAllCoroutines();
            podeContinuar = true;
            ProximoTutorial();
        }
    }

    private IEnumerator QuintaAcao()
    {
        tutoriaAreaClique.raycastTarget = false;
        podeContinuar = false;
        evidencia1.gameObject.SetActive(true);
        distribuidor.pedidosColocados.botaoOK.interactable = false;
        tutorialJanela.localPosition = new Vector2(302.0f, 195.4f);        

        yield return lowWaitTime;
        evidencia1.sizeDelta = new Vector2(391.7f, 67.9f);
        evidencia1.localPosition = new Vector2(0.0f, 332.6f);

        semana++;
        semanaCont.TrocaSemana(semana);
        AudioPlayer.instance.PlaySFX(semanaClip);
        yield return highWaitTime;

        evidencia1.gameObject.SetActive(false);

        fabrica.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
        yield return lowWaitTime;
        
        distribuidor.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
        yield return lowWaitTime;
  
        atacadista.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
        yield return lowWaitTime;
        
        varejista.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
        yield return lowWaitTime;

        evidencia1.gameObject.SetActive(true);
        evidencia1.sizeDelta = new Vector2(253.0f, 96.9f);
        evidencia1.localPosition = new Vector2(-558.3f, -259.5f);
        podeContinuar = true;
        tutoriaAreaClique.raycastTarget = true;

        if (!voltando)
        {
            fornecedorDaFabrica = fabrica.pedidosColocados.PegaPedidos();
            fabrica.pedidosRecebidos.AdicionaPedidos(5);
            distribuidor.pedidosRecebidos.AdicionaPedidos(5);
            atacadista.pedidosRecebidos.AdicionaPedidos(5);
            varejista.pedidosRecebidos.AdicionaPedidos(5);
            varejista.pedidosRecebidos.AdicionaPedidos(Random.Range(3, 7));
        }
        voltando = false;
    }
}