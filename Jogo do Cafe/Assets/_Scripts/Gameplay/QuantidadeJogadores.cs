using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantidadeJogadores : MonoBehaviour
{
    public void Jogadores(bool multiplayer)
    {
        if(multiplayer)
        {
            PlayerPrefs.SetInt("Multiplayer", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Multiplayer", 0);
        }
    }
}
