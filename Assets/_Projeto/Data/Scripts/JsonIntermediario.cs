using UnityEditor;
using UnityEngine;

using System.IO;
using System.Linq;

using com.Icypeak.VotacaoJogo.Jogo;

namespace com.Icypeak.VotacaoJogo.Data
{
    public static class JsonIntermediario
    {
        public static string JsonFileName = "50Jogos";
        [MenuItem("Jogos/Caio mama nois")]
        public static void SincronizarArquivosComJson()
        {
            string diretorioOutputObjetos = Path.Combine(Application.dataPath, "_Projeto", "Resources", "Objetos", "Jogo");
            string diretorioParcialOutputObjetos = Path.Combine("Assets", "_Projeto", "Resources", "Objetos", "Jogo");

            var arquivoJson = Resources.Load<TextAsset>(JsonFileName);
            var dataJson = JsonUtility.FromJson<ArrayJogoMainData>(arquivoJson.text);

            var generosJogos = dataJson.Jogos.Select(jogo => jogo.Genero).Distinct().ToList();
            var nomesJogos = dataJson.Jogos.Select(jogo => jogo.Nome).Distinct().ToList();

            Diretorio.CriarDiretorios(generosJogos, diretorioOutputObjetos);
            Diretorio.RemoverDiretoriosNaoListados(generosJogos, diretorioOutputObjetos);
            Arquivo.AdicionarAssets(dataJson, diretorioOutputObjetos, diretorioParcialOutputObjetos);
            Arquivo.RemoverAssetsNaoListados(generosJogos, nomesJogos, diretorioParcialOutputObjetos);

            AssetDatabase.Refresh();
        }

        public static JogoMainData[] RetornarArrayJogos()
        {
            var arquivoJson = Resources.Load<TextAsset>(JsonFileName);
            var dataJson = JsonUtility.FromJson<ArrayJogoMainData>(arquivoJson.text);

            return dataJson.Jogos;
        }
    }
}

