using System.Collections.Generic;
using SerializerFactory;
using LojaAPIClient.Model;

namespace LojaAPIClient {

    public class TestSerializer {

        public static void Main(string[] args) {
            
        }

        //  Test OK
        public static string serializeObjectToJson() {
            Produto videogame = new Produto(77, "Xbox One", 2, 3);
            List<Produto> produtos = new List<Produto>();
            produtos.Add(videogame);
            Carrinho carrinho = new Carrinho();
            carrinho.Endereco = "Comerciante José Formiga de Assis, 77";
            carrinho.Id = 2;
            carrinho.Produtos = produtos;

            string json = MySerializer.SerializeObjectToJson(carrinho);
            return json;
        }

        //  Test OK
        public static string serializeObjectToXml() {
            Produto videogame = new Produto(77, "Xbox One", 2, 3);
            List<Produto> produtos = new List<Produto>();
            produtos.Add(videogame);
            Carrinho carrinho = new Carrinho();
            carrinho.Endereco = "Comerciante José Formiga de Assis, 77";
            carrinho.Id = 2;
            carrinho.Produtos = produtos;

            string xml = MySerializer.SerializeObjectToXml(carrinho);
            return xml;
        }

        //  Test OK
        public static Carrinho deserializeJsonToObject() {
            Carrinho carrinho = new Carrinho();
            carrinho = MySerializer.DeserializeJsonToObject<Carrinho>(serializeObjectToJson());
            return carrinho;
        }

        //  Test OK
        public static Carrinho deserializeXmlToObject() {
            Carrinho carrinho = new Carrinho();
            carrinho = MySerializer.DeserializeXmlToObject<Carrinho>(serializeObjectToXml());
            return carrinho;
        }

    }
}
