using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using com.Icypeak.VotacaoJogo.Jogo;
using com.Icypeak.VotacaoJogo.Utils;

namespace com.Icypeak.VotacaoJogo.UI
{
    public class BotaoToggle : MonoBehaviour
    {
        public JogoScriptable Jogo;
        Button _btn;

        public static Action<JogoScriptable> OnSelect;
        ColorBlock colors;

        [SerializeField] Image icone;
        [SerializeField] TextMeshProUGUI titulo;

        void Awake()
        {
            _btn = GetComponent<Button>();
            colors = _btn.colors;
            this.gameObject.SetActive(false);
        }

        void OnEnable()
        {
            OnSelect += DeSelect;
            FillPanelWithGameCards.OnSyncGameCards += HighlightSelectedGame;
        }
        void OnDisable()
        {
            OnSelect -= DeSelect;
            FillPanelWithGameCards.OnSyncGameCards -= HighlightSelectedGame;
        }

        public void Inicializar(JogoScriptable jogo)
        {
            Jogo = jogo;
            icone.sprite = jogo.Icone;
            titulo.text = jogo.Nome;
            this.gameObject.SetActive(true);
        }

        private void OnClick()
        {
            OnSelect?.Invoke(Jogo);
            Select();
        }

        private void Select()
        {
            colors.normalColor = Color.green;
            colors.selectedColor = Color.green;
            colors.highlightedColor = Color.green;

            _btn.colors = colors;
        }

        private void DeSelect(JogoScriptable jogo)
        {
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            colors.highlightedColor = Color.white;

            _btn.colors = colors;
        }

        private void HighlightSelectedGame()
        {
            if (VotoManager.JogosSelecionados[GeneroManager.GeneroPosArray] is null) return;
            if (VotoManager.JogosSelecionados[GeneroManager.GeneroPosArray].Nome == Jogo.Nome)
            {
                Select();
            }
        }
    }
}