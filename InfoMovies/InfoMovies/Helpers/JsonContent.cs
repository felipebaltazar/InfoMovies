using System.Net.Http;
using System.Text;

namespace InfoMovies.Helpers
{
    public sealed class JsonContent : StringContent
    {
        public JsonContent(string content) 
            : base(content, Encoding.UTF8, "application/json")
        { }
    }
}