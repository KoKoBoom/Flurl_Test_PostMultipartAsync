using Flurl.Http;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = "http://localhost:64728/Default.aspx";

            var res1 = url
                .PostMultipartAsync(m => m
                    .AddString("key1", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("name", "img.png")
                    )
                .ReceiveString()
                .Result;

            var res2 = url
                .PostMultipartAsync(m => m
                    .AddString("\"quoted-key1\"", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("\"quoted-name\"", "img.png")
                    )
                .ReceiveString()
                .Result;

            var res3 = url
                .PostMultipartAsync(m => m
                    .AddString("key1", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("name", File.OpenRead("img.png"), "fileName"))
                .ReceiveString()
                .Result;

            var res4 = url
                .PostMultipartAsync(m => m
                    .AddString("\"key1\"", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("\"quoted-name\"", File.OpenRead("img.png"), "fileName"))
                .ReceiveString()
                .Result;

            var res5 = url
                .PostMultipartAsync(m => m
                    .AddString("\"key1\"", "value1")
                    .AddStringParts(new { key2 = "value2" })
                    .AddFile("\"quoted-name\"", File.OpenRead("img.png"), "\"quoted-fileName\""))
                .ReceiveString()
                .Result;
        }
    }
}
