using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplayerMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _nomeDoJogador;
    [SerializeField] private TMP_Text _nomeDaSala;

    public void CriaSala()
    {
        GestorDeRede.Instancia.MudaNick(_nomeDoJogador.text);
        GestorDeRede.Instancia.CriaSala(_nomeDaSala.text);
    }

    public void EntraSala()
    {
        GestorDeRede.Instancia.MudaNick(_nomeDoJogador.text);
        GestorDeRede.Instancia.EntraSala(_nomeDaSala.text);
    }
}
