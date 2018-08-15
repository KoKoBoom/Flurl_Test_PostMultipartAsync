using Flurl.Http;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var res1 = "http://localhost:64728/Default.aspx"
                .PostMultipartAsync(m => m
                    .AddString("key1", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("name", "img.png")
                    )
                .ReceiveString()
                .Result;

            var res2 = "http://localhost:64728/Default.aspx"
                .PostMultipartAsync(m => m
                    .AddString("\"quoted-key1\"", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("\"quoted-name\"", "img.png")
                    )
                .ReceiveString()
                .Result;

            var res3 = "http://localhost:64728/Default.aspx"
                .PostMultipartAsync(m => m
                    .AddString("key1", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("name", File.OpenRead("img.png"), "fileName"))
                .ReceiveString()
                .Result;

            var res4 = "http://localhost:64728/Default.aspx"
                .PostMultipartAsync(m => m
                    .AddString("\"key1\"", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("\"quoted-name\"", File.OpenRead("img.png"), "\"quoted-fileName\""))
                .ReceiveString()
                .Result;
        }
    }
}
