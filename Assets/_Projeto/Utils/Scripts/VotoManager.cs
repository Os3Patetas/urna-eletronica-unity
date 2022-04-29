using UnityEngine;

using com.Icypeak.VotacaoJogo.Jogo;
using com.Icypeak.VotacaoJogo.UI;

namespace com.Icypeak.VotacaoJogo.Utils
{
    public class VotoManager : MonoBehaviour
    {
        public static JogoScriptable[] JogosSelecionados;

        void Awake() => JogosSelecionados = new JogoScriptable[GeneroManager.Generos.Length];


        void OnEnable()
        {
            BotaoToggle.OnSelect += SelecionarJogo;
            Diretor.OnFinish += ContabilizarVotos;
        }
        void OnDisable()
        {
            BotaoToggle.OnSelect -= SelecionarJogo;
            Diretor.OnFinish -= ContabilizarVotos;
        }

        void SelecionarJogo(JogoScriptable jogoSelecionado) =>
             JogosSelecionados[GeneroManager.GeneroPosArray] = jogoSelecionado;

        void ContabilizarVotos()
        {
            int i = 0;
            foreach (var jogo in JogosSelecionados)
            {
                jogo.Votos++;
                JogosSelecionados[i++] = null;
            }
        }
    }
}