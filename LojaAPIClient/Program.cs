using LojaAPIClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LojaAPIClient {

    public class Program {

        //  URL Base
        private const string URL = "http://localhost:60206/api/carrinho/2";

        //  Métodos
        private const string GET    = "GET";
        private const string POST   = "POST";
        private const string PUT    = "PUT";
        private const string DELETE = "DELETE";

        //  Corpo da requisição
        private static string body = string.Empty;

        //  JSON enviado no POST
        private static string json = string.Empty;

        //  XML enviado no POST
        private static string xml = string.Empty;

        public static void Main(string[] args) {
            requestGET();
            //  requestPOST();
            //  requestGETXml();
            //  requestPOSTXml();
            //  requestPOSTWithResponseMessage();
        }

        //  Requisição GET para um WebService
        private static void requestGET() {

            //  Realiza a requisição
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL);
            request.Method = GET;

            //  Aqui eu escolho o que eu quero receber JSON ou XML
            request.Accept = "application/json";

            HttpWebResponse response = null;

            try {
                //  Guarda a resposta da minha requisição
                response = (HttpWebResponse) request.GetResponse();

                //  Ler os dados da minha resposta
                using (Stream responseStream = response.GetResponseStream()) {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    body = reader.ReadToEnd();
                }
                Console.Write(body);
                Console.Read();
            } catch (WebException e) {
                Console.Write(e.Message);
                Console.Read();
            }
        }

        //  Requisição POST para o WebServices
        private static void requestPOST() {

            //  Realiza a requisição
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL);
            request.Method = POST;

            //  O que eu vou receber como retorno
            request.Accept = "application/json";

            //  O que eu estou enviando na minha requisição
            request.ContentType = "application/json";

            //  JSON enviado
            json = "{'Produtos': [{'Id': 57,'Preco': 999,'Nome': 'Wii U Client 6','Quantidade': 1}],'Endereco': 'Av. Epitácio Pessoa, 1446'}";

            //  Preciso transformar meu JSON em um array de bytes para fazer minha requisição
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            //  Escreve o meu array de bytes no corpo da requisição
            //  1º parâmetro - Meu array de bytes 
            //  2º parâmetro - A partir de qual posição do meu array eu quero que ele comece a escrever, no caso do início 0
            //  3º parâmetro - Quero que ele escreva até o fim do meu array
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            //  Guarda a resposta da minha requisição
            WebResponse response = request.GetResponse();

            //  Ler os dados da minha resposta
            using(Stream responseStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                body = reader.ReadToEnd();
            }
            Console.Write(body);
            Console.Read();

            //  Testar o serializer
            Produto videogame = new Produto(77, "Xbox One", 2, 3);
            List<Produto> produtos = new List<Produto>();
            produtos.Add(videogame);
            Carrinho carrinho = new Carrinho();
            carrinho.Endereco = "Comerciante José Formiga de Assis, 77";
            carrinho.Id = 2;
            carrinho.Produtos = produtos;
        }

        private static void requestGETXml() {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = GET;
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();

            using(Stream responseStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                body = reader.ReadToEnd();
            }
            Console.Write(body);
            Console.Read();
        }

        private static void requestPOSTXml() {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = POST;
            request.Accept = "application/xml";
            request.ContentType = "application/xml";

            xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/LojaAPI.Models'><Endereco>Av. Epitácio Pessoa, 1446</Endereco><Produtos><Produto><Id>33</Id><Nome>POST Xml</Nome><Preco>1</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);

            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            WebResponse response = request.GetResponse();

            using(Stream responseStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                body = reader.ReadToEnd();
            }
            Console.Write(body);
            Console.Read();
        }

        private static void requestPOSTWithResponseMessage() {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = POST;
            request.Accept = "application/json";
            request.ContentType = "application/json";

            json = "{'Produtos': [{'Id': 57,'Preco': 999,'Nome': 'Wii U Client 6','Quantidade': 1}],'Endereco': 'Av. Epitácio Pessoa, 1446'}";

            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.ReadLine();
        }
    }
}
