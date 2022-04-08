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
                _genero = value;

                if (_genero < 0 || _genero > Generos.Length - 1)
                    _genero = Mathf.Clamp(_genero, 0, Generos.Length);
                else
                    OnGeneroChange?.Invoke();
            }
        }

        public static JogoScriptable[] JogosGeneroAtual => Diretor.ListaJogos.Where(jogo => string.Compare(jogo.Genero, GeneroAtual) == 0)
                                                                             .Select(jogo => jogo)
                                                                             .ToArray();

        public static Action OnGeneroChange;

        void Awake() =>
           Generos = Diretor.ListaJogos.Select(jogo => jogo.Genero).Distinct().ToArray();

        void OnEnable()
        {
            Diretor.OnVotarNovamente += ResetarGeneroPos;
        }
        void OnDisable()
        {
            Diretor.OnVotarNovamente -= ResetarGeneroPos;
        }
        private void ResetarGeneroPos()
        {
            GeneroPosArray = 0;
        }

        public void ProximoGenero() => GeneroPosArray++;
        public void GeneroAnterior() => GeneroPosArray--;
    }
}
