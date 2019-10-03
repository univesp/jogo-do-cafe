using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Transporte : MonoBehaviour
{
    [SerializeField] private GameObject pai;
    [SerializeField] private GameObject paiTemporario;

    [SerializeField] private List<Waypoint> waypoints;
    [SerializeField] private int index = 0;

    private float distancia = 0.05f;
    private float velocidade = 10;

    [SerializeField] private bool espera = true;

    [SerializeField] private Expedicao expedicao;
    public TextMeshProUGUI cargaTexto;
    [SerializeField] private Vector3 posicaoInicial;
    [SerializeField] private Vector3 rotacaoInicial;

    [SerializeField] private bool manterPosicao;

    //Essa parte é só para os veículos do centro de distribuição. Ele precisa ser um navio no começo e trocar para um caminhão depois
    [SerializeField] private GameObject caminhao;
    [SerializeField] private GameObject navio;
    [SerializeField] private Vector3 novaPosicao;
    [SerializeField] private bool isCD;

    private void OnEnable()
    {
        EventManager.OnCall += PodeMover;
        if (manterPosicao)
        {
            manterPosicao = false;
        }
        else
        {
            transform.SetParent(paiTemporario.transform);         
            transform.localPosition = posicaoInicial;
            transform.localEulerAngles = rotacaoInicial;
            if(isCD)
            {
                caminhao.SetActive(false);
                navio.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        EventManager.OnCall -= PodeMover;
    }

    private void FixedUpdate()
    {
        if (!espera)
        {
            Movimento();
        }
    }

    private void Movimento()
    {        

        transform.forward = waypoints[index].transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[index].transform.position) <= distancia)
        {
            if (waypoints[index].isSpecialEvent)
            {
                espera = true;
            }
            if(waypoints[index].changeVehicle)
            {
                caminhao.SetActive(true);
                navio.SetActive(false);
                transform.localPosition = novaPosicao;
            }
            index++;
            if (index >= waypoints.Count)
            {
                espera = true;
                index = 0;
                transform.SetParent(pai.transform);
                EventManager.OnCall -= PodeMover;
                gameObject.SetActive(false);                
            }
        }
    }

    private void PodeMover()
    {
        if (gameObject.activeSelf)
        {
            espera = false;
            //expedicao.UIText.text = "0";
        }
    }

    public bool GetEspera()
    {
        return espera;
    }
}