using UnityEngine;

using System.IO;
using System.Collections.Generic;

using com.Icypeak.VotacaoJogo.Jogo;
using com.Icypeak.VotacaoJogo.Data;

namespace com.Icypeak.VotacaoJogo.Utils
{
    public class Diretor : MonoBehaviour
    {
        public static List<JogoScriptable> ListaJogos;

        void Awake() =>
            PreencherListaJogos();

        private void PreencherListaJogos()
        {
            ListaJogos = new List<JogoScriptable>();

            var jogos = JsonIntermediario.RetornarArrayJogos();
            var todosJogos = Resources.LoadAll(Path.Combine("Objetos/Jogo"), typeof(JogoScriptable));
            foreach (var jogo in todosJogos)
                ListaJogos.Add((JogoScriptable)jogo);
        }
    }
}

