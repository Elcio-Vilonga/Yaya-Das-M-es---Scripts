using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text _listaDeJogadores;
    [SerializeField] private Button _comecaJogo;

    [PunRPC]

    public void ActualizaLista()
    {
        _listaDeJogadores.text = GestorDeRede.Instancia.ObterListaDeJogadores();
        _comecaJogo.interactable = GestorDeRede.Instancia.DonoDaSala();
    }
}
