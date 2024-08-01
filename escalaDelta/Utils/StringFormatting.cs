using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escalaDelta.Utils {
    public class StringFormatting {
        public static string FormatItems<T>(IEnumerable<T> items, int numColunas) {
            List<T> itemList = new List<T>(items);
            int partSize = (itemList.Count + numColunas - 1) / numColunas; // Arredondar para cima

            // Criação de listas de sublistas
            List<List<T>> colunas = new List<List<T>>();
            for (int i = 0; i < numColunas; i++) {
                int startIndex = i * partSize;
                int count = Math.Min(partSize, itemList.Count - startIndex);
                colunas.Add(itemList.GetRange(startIndex, count));
            }

            string formattedString = "";
            for (int i = 0; i < partSize; i++) {
                List<string> row = new List<string>();
                for (int j = 0; j < numColunas; j++) {
                    if (i < colunas[j].Count) {
                        row.Add(colunas[j][i]?.ToString() ?? "");
                    } else {
                        row.Add("");
                    }
                }
                formattedString += string.Join("\t", row) + "\n";
            }

            return formattedString;
        }

    }
}
