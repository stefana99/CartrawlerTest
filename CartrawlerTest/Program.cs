using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;



namespace CartrawlerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OTA_PingRQ rq = new OTA_PingRQ();
            rq.EchoData = "hello world";
            
            


            Console.WriteLine("hi");
           
            string myxml = ToXMLString(rq);

            var myrequest = WebRequest.Create("http://otatest.cartrawler.com:20002/cartrawlerota");
            myrequest.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(myxml);
            myrequest.ContentType = "xml";
            myrequest.ContentLength = byteArray.Length;
            Stream dataStream = myrequest.GetRequestStream();
            dataStream.Write(byteArray,0,byteArray.Length);
            dataStream.Close();

            WebResponse response = myrequest.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();


        }

        static string ToXMLString(object xmlObject)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;
            settings.NewLineChars = "";
            settings.NewLineHandling = NewLineHandling.None;

            StringWriter stringWriter = new StringWriter();

            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(xmlObject.GetType());
            serializer.Serialize(xmlWriter, xmlObject, namespaces);

            return stringWriter.ToString();
        }
    }
}
