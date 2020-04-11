using Newtonsoft.Json;

namespace TestRabbit
{
    public interface IConvert
    {
        public string Run(string data);
        public string JsonToXml(string data);
        public string XmlToJson(string data);
    }

    public class ConvertBasic : IConvert
    {
        public string Run(string data)
        {
            return data.Replace('a', '@');
        }

        public string JsonToXml(string data)
        {
            var result = JsonConvert.DeserializeXNode(data, "Root");
            return string.Empty;
        }

        public string XmlToJson(string data)
        {
            throw new System.NotImplementedException();
        }
    }
}
