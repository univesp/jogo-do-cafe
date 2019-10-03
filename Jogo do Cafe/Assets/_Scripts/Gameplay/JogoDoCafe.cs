using System.Collections;
using UnityEngine;
using TMPro;

public class JogoDoCafe : MonoBehaviour
{
    [SerializeField] private AudioClip envelopeSFX;
    [SerializeField] private AudioClip semanaSFX;

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

    [SerializeField] private TransicaoDeTela transicao;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Multiplayer", 0) == 0)
        {
            fabrica.pedidosColocados.isPC = true;
            distribuidor.pedidosColocados.isPC = false;
            atacadista.pedidosColocados.isPC = true;
            varejista.pedidosColocados.isPC = true;
        }
        else
        {
            fabrica.pedidosColocados.isPC = false;
            distribuidor.pedidosColocados.isPC = false;
            atacadista.pedidosColocados.isPC = false;
            varejista.pedidosColocados.isPC = false;
        }
    }

    private void Start()
    {
        StartCoroutine(ComecaJogo());
    }    

    public void PlayerInput(Setor _setor)
    {
        if(_setor == fabrica)
        {
            fabrica.pedidosColocados.botaoOK.interactable = false;
            if (fabrica.pedidosColocados.PegaPedidos() > 0)
            {
                fabrica.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                AudioPlayer.instance.PlaySFX(envelopeSFX);
            }
        }

        if(_setor == distribuidor)
        {
            distribuidor.pedidosColocados.botaoOK.interactable = false;
            if (distribuidor.pedidosColocados.PegaPedidos() > 0)
            {
                distribuidor.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                AudioPlayer.instance.PlaySFX(envelopeSFX);
            }
        }

        if(_setor == atacadista)
        {            
            atacadista.pedidosColocados.botaoOK.interactable = false;
            if (atacadista.pedidosColocados.PegaPedidos() > 0)
            {
                atacadista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                AudioPlayer.instance.PlaySFX(envelopeSFX);
            }
        }

        if(_setor == varejista)
        {
            varejista.pedidosColocados.botaoOK.interactable = false;
            if (varejista.pedidosColocados.PegaPedidos() > 0)
            {
                varejista.pedidosColocados.notificacaoAnimator.gameObject.SetActive(true);
                AudioPlayer.instance.PlaySFX(envelopeSFX);
            }
        }
        playersPlayed++;

        //Se jogar sozinho, apenas um "Ok" basta para ir para a próxima semana
        if (PlayerPrefs.GetInt("Multiplayer", 0) == 0)
        {
            //Passa para a semana seguinte
            semana++;
            semanaCont.TrocaSemana(semana);
            StartCoroutine(QuintaAcao());                               
        }
        //Senão, precisa dos 4 "Oks" para prosseguir
        else
        {
            if(playersPlayed == 4)
            {
                //Passa para a semana seguinte
                StartCoroutine(QuintaAcao());
                AudioPlayer.instance.PlaySFX(semanaSFX);
                semana++;
                semanaCont.TrocaSemana(semana);                
            }
        }        
    }

    private IEnumerator ComecaJogo()
    {
        yield return highWaitTime;

        StartCoroutine(SegundaAcao());
    }

    private IEnumerator PrimeiraAcao()
    {
        //Manda do caminhão para o estoque
        fabrica.recebimento.EnviaParaEstoque();
        distribuidor.recebimento.EnviaParaEstoque();
        atacadista.recebimento.EnviaParaEstoque();
        varejista.recebimento.EnviaParaEstoque();

        yield return highWaitTime;

        StartCoroutine(SegundaAcao());
    }

    private IEnumerator SegundaAcao()
    {
        //Produtos vão para expedição        
        fabrica.pedidosRecebidos.RetiraPedidos();
        distribuidor.pedidosRecebidos.RetiraPedidos();
        atacadista.pedidosRecebidos.RetiraPedidos();
        varejista.pedidosRecebidos.RetiraPedidos();

        yield return lowWaitTime;

        fabrica.estoque.ContaCusto();
        distribuidor.estoque.ContaCusto();
        atacadista.estoque.ContaCusto();
        varejista.estoque.ContaCusto();

        fabrica.backlog.CobraPendencias();
        distribuidor.backlog.CobraPendencias();
        atacadista.backlog.CobraPendencias();
        varejista.backlog.CobraPendencias();

        yield return lowWaitTime;
        
        if (semana < 15)
        {
            //Faz os campos aparecerem pro jogador
            TerceiraAcaoPC();
            if(!fabrica.pedidosColocados.isPC)
            {
                fabrica.pedidosColocados.botaoOK.interactable = true;
            }
            if (!distribuidor.pedidosColocados.isPC)
            {
                distribuidor.pedidosColocados.botaoOK.interactable = true;
            }
            if (!atacadista.pedidosColocados.isPC)
            {
                atacadista.pedidosColocados.botaoOK.interactable = true;
            }
            if (!varejista.pedidosColocados.isPC)
            {
                varejista.pedidosColocados.botaoOK.interactable = true;
            }
        }
        else
        {
            //Chama a transição antes de chamar o gameover
            transicao.ChamaTransicao(0.0f);            
        }
    }

    public void TerceiraAcaoPC()
    {
        if (fabrica.pedidosColocados.isPC)
        {
            IA.CalculoMedio(fabrica);
        }

        if (distribuidor.pedidosColocados.isPC)
        {
            IA.CalculoMedio(distribuidor);
        }

        if (atacadista.pedidosColocados.isPC)
        {
            IA.CalculoMedio(atacadista);
        }

        if (varejista.pedidosColocados.isPC)
        {
            IA.CalculoMedio(varejista);
        }
    }


    private IEnumerator QuartaAcao()
    {
        //Faz animações dos caminhões andando na estrada          
        EventManager.CallAction();
        yield return highWaitTime;

        //Move da expedição pra estrada e move os caminhões     
        estradaFabrica.RecebeCarga(fornecedorDaFabrica);
        fabrica.expedicao.EnviaEstrada();
        distribuidor.expedicao.EnviaEstrada();
        atacadista.expedicao.EnviaEstrada();
        varejista.expedicao.EnviaEstrada();

        StartCoroutine(PrimeiraAcao());
    }

    private IEnumerator QuintaAcao()
    {
        yield return highWaitTime;
        //Passa os pedidos colocados para os pedidos recebidos

        //FAZER UM POR UM DA ANIMAÇÃO DA MENSAGEM
        if (fabrica.pedidosColocados.notificacaoAnimator.gameObject.activeSelf)
        {
            fabrica.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
            yield return lowWaitTime;
            fornecedorDaFabrica = fabrica.pedidosColocados.PegaPedidos();
            fabrica.pedidosColocados.PassaParaPedidosRecebidos();
        }                

        if(distribuidor.pedidosColocados.notificacaoAnimator.gameObject.activeSelf)
        {
            distribuidor.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
            yield return lowWaitTime;
            distribuidor.pedidosColocados.PassaParaPedidosRecebidos();
        }
               
        if(atacadista.pedidosColocados.notificacaoAnimator.gameObject.activeSelf)
        {
            atacadista.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
            yield return lowWaitTime;
            atacadista.pedidosColocados.PassaParaPedidosRecebidos();
        }
        
        if(varejista.pedidosColocados.notificacaoAnimator.gameObject.activeSelf)
        {
            varejista.pedidosColocados.notificacaoAnimator.Play("MensagemEnvia");
            yield return lowWaitTime;
            varejista.pedidosColocados.PassaParaPedidosRecebidos();            
        }

        int encomenda = Random.Range(3, 7);
        varejista.pedidosRecebidos.AdicionaPedidos(encomenda);

        yield return lowWaitTime;

        StartCoroutine(QuartaAcao());
    }
}