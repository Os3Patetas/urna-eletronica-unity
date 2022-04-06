using UnityEngine;

using System.Linq;

using com.Icypeak.VotacaoJogo.Utils;
using com.Icypeak.VotacaoJogo.Jogo;

namespace com.Icypeak.VotacaoJogo.UI
{
    public class FillPanelWithGameCards : MonoBehaviour
    {
        [SerializeField] GameObject card;

        void Awake() => SincronizarGameCards();

        void OnEnable() => GeneroManager.OnGeneroChange += SincronizarGameCards;
        void OnDisable() => GeneroManager.OnGeneroChange -= SincronizarGameCards;

        private void SincronizarGameCards()
        {
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (var jogo in GeneroManager.JogosGeneroAtual)
            {
                var instance = Instantiate(card, this.transform.position, this.transform.rotation);
                instance.transform.SetParent(this.gameObject.transform);
                instance.GetComponent<BotaoToggle>().Inicializar(jogo);
            }
        }
    }
}
