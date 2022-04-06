using UnityEngine;

namespace com.Icypeak.VotacaoJogo.Jogo
{
    [CreateAssetMenu(fileName ="Jogo", menuName ="Jogo/New")]
    [System.Serializable]
    public class JogoScriptable : ScriptableObject
    {
        public string Nome;
        public string Genero;
        public Sprite Icone;
        public int Votos;
    }
}
