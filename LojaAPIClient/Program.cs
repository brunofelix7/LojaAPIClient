using LojaAPIClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LojaAPIClient {

    public class Program {

        //  URL Base
        private const string URL = "http://localhost:60206/api/carrinho/1";

        //  Métodos
        private const string GET    = "GET";
        private const string POST   = "POST";
        private const string PUT    = "PUT";
        private const string DELETE = "DELETE";

        //  Corpo da requisição
        private static string body = string.Empty;

        public static void Main(string[] args) {
            requestGET();
        }

        //  Requisição GET para um WebService
        private static void requestGET() {

            //  Realiza a requisição
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL);
            request.Method = GET;
            request.Accept = "application/xml";
            request.ContentType = "application/json";

            //  Guarda a resposta da minha requisição
            WebResponse response = request.GetResponse();

            //  Ler os dados da minha resposta
            using(Stream responseStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                body = reader.ReadToEnd();
            }
            //  Testar deserializer

            Console.Write(body);
            Console.Read();
        }

        //  Requisição POST para o WebServices
        private static void requestPOST() {
            Produto videogame = new Produto(7745, "Xbox One", 1200, 3);
            List<Produto> produtos = new List<Produto>();
            produtos.Add(videogame);
            Carrinho carrinho = new Carrinho();
            carrinho.Endereco = "Comerciante José Formiga de Assis, 77";
            carrinho.Id = 2;
            carrinho.Produtos = produtos;
        }
    }
}
