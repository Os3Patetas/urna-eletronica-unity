using UnityEngine;

using System;
using System.IO;
using System.Collections.Generic;

using com.Icypeak.VotacaoJogo.Jogo;
using com.Icypeak.VotacaoJogo.Data;

namespace com.Icypeak.VotacaoJogo.Utils
{
    public class Diretor : MonoBehaviour
    {
        public static List<JogoScriptable> ListaJogos;
        public static Action OnFinish;
        public static Action OnVotarNovamente;
        public GameObject PreviousButton;
        public GameObject NextButton;
        public GameObject FinishButton;
        public GameObject VotacaoUI;
        public GameObject FimVotacaoUI;

        void Awake() =>
            PreencherListaJogos();

        void OnEnable()
        {
            GeneroManager.OnGeneroChange += AtualizarBotoes;
        }
        void OnDisable()
        {
            GeneroManager.OnGeneroChange -= AtualizarBotoes;
        }

        private void PreencherListaJogos()
        {
            ListaJogos = new List<JogoScriptable>();

            var jogos = JsonIntermediario.RetornarArrayJogos();
            var todosJogos = Resources.LoadAll(Path.Combine("Objetos/Jogo"), typeof(JogoScriptable));
            foreach (var jogo in todosJogos)
                ListaJogos.Add((JogoScriptable)jogo);
        }

        private void AtualizarBotoes()
        {
            if (GeneroManager.GeneroPosArray > 0)
                PreviousButton.SetActive(true);
            else
                PreviousButton.SetActive(false);

            if (GeneroManager.GeneroPosArray == GeneroManager.Generos.Length - 1)
            {
                NextButton.SetActive(false);
                FinishButton.SetActive(true);
            }
            else
            {
                NextButton.SetActive(true);
                FinishButton.SetActive(false);
            }
        }



        public void FinishButtonClick()
        {
            if (VotoManager.JogosSelecionados[GeneroManager.GeneroPosArray] is not null)
            {
                VotacaoUI.SetActive(false);
                FimVotacaoUI.SetActive(true);
                OnFinish?.Invoke();
            }
        }

        public void VotarNovamenteClick()
        {
            VotacaoUI.SetActive(true);
            FimVotacaoUI.SetActive(false);
            OnVotarNovamente?.Invoke();
        }
    }
}

