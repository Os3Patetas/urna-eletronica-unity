using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using com.Icypeak.VotacaoJogo.Jogo;

namespace com.Icypeak.VotacaoJogo.Data
{
    public static class Arquivo
    {
        public static void AdicionarAssets(ArrayJogoMainData dataJson, string fullOutputDir, string outputDir)
        {
            foreach (var jogo in dataJson.Jogos)
            {
                string localizacaoAsset = Path.Combine(fullOutputDir, jogo.Genero, jogo.Nome + ".asset");
                if (File.Exists(localizacaoAsset)) continue;

                localizacaoAsset = Path.Combine(outputDir, jogo.Genero, jogo.Nome + ".asset");

                localizacaoAsset = AssetDatabase.GenerateUniqueAssetPath(localizacaoAsset);
                JogoScriptable jogoScriptable = ScriptableObject.CreateInstance<JogoScriptable>();
                jogoScriptable.Nome = jogo.Nome;
                jogoScriptable.Genero = jogo.Genero;
                jogoScriptable.Icone = Resources.Load<Sprite>("Arte/" + jogo.Nome);

                AssetDatabase.CreateAsset(jogoScriptable, localizacaoAsset);
                AssetDatabase.SaveAssets();
            }
        }

        public static void RemoverAssetsNaoListados(List<string> generosJogos, List<string> nomesJogos, string outputDir)
        {
            foreach (var genero in generosJogos)
            {
                string generoDiretorio = Path.Combine(outputDir, genero);
                string[] assetsNoDiretorio = Directory.GetFiles(generoDiretorio, "*.asset");

                foreach (var asset in assetsNoDiretorio)
                {
                    string assetName = asset.Remove(0, generoDiretorio.Length + 1).Replace(".asset", "");

                    if (nomesJogos.Contains(assetName)) continue;
                    File.Delete(asset);
                    File.Delete(asset + ".meta");
                }
            }
        }

    }
}
