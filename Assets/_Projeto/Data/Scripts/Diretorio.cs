using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.Icypeak.VotacaoJogo.Data
{
    public static class Diretorio
    {
        public static void CriarDiretorios(IEnumerable<string> ListaDiretorio, string outputDir)
        {
            foreach (var dir in ListaDiretorio)
            {
                if (Directory.Exists(Path.Combine(outputDir, dir))) continue;


                Directory.CreateDirectory(Path.Combine(outputDir, dir));
            }
        }

        public static void RemoverDiretoriosNaoListados(IEnumerable<string> ListaDiretorio, string outputDir)
        {
            string[] subDiretorios = Directory.GetDirectories(outputDir);
            foreach (var subDiretorio in subDiretorios)
            {
                string nomeSubDiretorio = subDiretorio.Remove(0, outputDir.Length + 1);
                if (ListaDiretorio.Contains(nomeSubDiretorio)) continue;

                Directory.Delete(subDiretorio);
                File.Delete(subDiretorio + ".meta");
            }
        }
    }
}

