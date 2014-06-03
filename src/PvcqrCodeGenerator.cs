using System.IO;
using System.Net;
using System.Security.Policy;
using System.Web;
using PvcCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvcPlugins
{
    public class QrCodeGenerator : PvcPlugin
    {
        int _width;
        int _height;
        public QrCodeGenerator(int width = 250,int height = 250)
        {
            _width = width;
            _height = height;
        }
        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            foreach (var inputStream in inputStreams)
            {
                StreamReader sr = new StreamReader(inputStream);
                string test = sr.ReadToEnd();
                if (test.Length <= 2000 )
                {
                    WebClient wc = new WebClient();
                    var data = wc.DownloadData("https://chart.googleapis.com/chart?cht=qr&chs="+_width+"x"+_height+"&chl=" + HttpUtility.UrlEncode(test));
                    MemoryStream ms = new MemoryStream(data);
                    var outputStreams = new List<PvcStream>();
                    outputStreams.Add(new PvcStream(() => ms));
                    return outputStreams;
                }
            }
            return inputStreams;
        }
    }
}
