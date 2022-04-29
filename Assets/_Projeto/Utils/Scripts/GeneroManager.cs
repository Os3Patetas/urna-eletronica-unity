using UnityEngine;

using System;
using System.Linq;

using com.Icypeak.VotacaoJogo.Jogo;

namespace com.Icypeak.VotacaoJogo.Utils
{
    public class GeneroManager : MonoBehaviour
    {
        public static string[] Generos { get; private set; }
        public static string GeneroAtual => Generos[_genero];
        static int _genero = 0;
        public static int GeneroPosArray
        {
            get => _genero;
            private set
            {
                if (VotoManager.JogosSelecionados[_genero] is not null || value < _genero)
                {
                    _genero = value;
                    OnGeneroChange?.Invoke();
                }
                else
                {
                    print("Nenhum jogo selecionado");
                }
            }
        }

        public static JogoScriptable[] JogosGeneroAtual => Diretor.ListaJogos.Where(jogo => string.Compare(jogo.Genero, GeneroAtual) == 0)
                                                                             .Select(jogo => jogo)
                                                                             .ToArray();

        public static Action OnGeneroChange;

        void Awake() =>
           Generos = Diretor.ListaJogos.Select(jogo => jogo.Genero).Distinct().ToArray();

        void OnEnable() => Diretor.OnVotarNovamente += ResetarGeneroPos;
        void OnDisable() => Diretor.OnVotarNovamente -= ResetarGeneroPos;

        private void ResetarGeneroPos()
        {
            _genero = 0;
            OnGeneroChange?.Invoke();
        }

        public void ProximoGenero() => GeneroPosArray++;
        public void GeneroAnterior() => GeneroPosArray--;
    }
}
