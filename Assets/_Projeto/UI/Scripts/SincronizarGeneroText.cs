using UnityEngine;
using TMPro;

using com.Icypeak.VotacaoJogo.Utils;

namespace com.Icypeak.VotacaoJogo.UI
{
    public class SincronizarGeneroText : MonoBehaviour
    {
        TextMeshProUGUI _textComponent;

        void Awake() =>
            _textComponent = GetComponent<TextMeshProUGUI>();

        void Start() =>
            _textComponent.text = GeneroManager.GeneroAtual;

        void OnEnable() => GeneroManager.OnGeneroChange += SincronizarTextComponent;
        void OnDisable() => GeneroManager.OnGeneroChange -= SincronizarTextComponent;

        private void SincronizarTextComponent() =>
            _textComponent.text = GeneroManager.GeneroAtual;
    }
}