using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WordOfTheDay
{
    class GenerateWordInfo
    {
        private static int GetRandNum()
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(370100);

            while (ChkRandNum(rndNum) == true)
            {
                rndNum = rnd.Next(370100);
            }

            return rndNum;
        }

        private static bool ChkRandNum(int num)
        {
            bool numIsUsed = false;
        
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(
                System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory
                ) + @"\words_used.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line == num.ToString())
                {
                    numIsUsed = true;
                }
            }

            file.Close();

            return numIsUsed;
        }
        
        private static void RemUsedNum(int usedNum)
        {
            string path = (System.AppDomain.CurrentDomain.BaseDirectory
                ) + @"\words_used.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(usedNum);
            }
        }

        public static Tuple<string, string, string, string, string> GetWord()
        {
            FINDWORD:;

            int rndNum = GetRandNum();
            int lineCount = 0;
            string lineWord;
            
            System.IO.StreamReader file = new System.IO.StreamReader(
                System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory
                ) + @"\words_alpha.txt");
            while ((lineWord = file.ReadLine()) != null)
            {
                if (lineCount == rndNum)
                {
                    //System.Console.WriteLine(lineWord);
                    break;
                }

                lineCount++;
            }

            file.Close();

            var wordData = new Tuple<string, string, string, string, string>("", "", "", "", "");

            wordData =  GetWordData(lineWord, rndNum);

            if (wordData.Item4 == "-empty-")
            {
                goto FINDWORD;
            }
            
            return wordData;
        }
        private static Tuple<string, string, string, string, string> GetWordData(string word, int rndNum)
        {
            string pronounce = "";
            string nounVerbAdj = "";
            string defOne = "";
            string defTwo = "";

            string responseFromServer = "";

            HttpWebRequest wordReq = (HttpWebRequest)WebRequest.Create(
                "https://www.dictionaryapi.com/api/v1/references/collegiate/xml/" + 
                word + "?key=68ac85aa-372d-47c2-9515-e2e456cb3374"
                );

            WebResponse wordRes = wordReq.GetResponse();

            if (((HttpWebResponse)wordRes).StatusDescription == "OK")
            {
                Stream dataStream = wordRes.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();

                reader.Close();
            }

            wordRes.Close();

            if ((responseFromServer.IndexOf("suggestion") != -1) || (responseFromServer == "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<entry_list version=\"1.0\">\n\t</entry_list>"))
            {
                RemUsedNum(rndNum);
                Console.WriteLine("Bad Number: " + rndNum);
            }

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                doc.LoadXml(responseFromServer);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.Out.WriteLine("FileNotFoundException");
            }

            doc.LoadXml(responseFromServer);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);

            XmlElement root = doc.DocumentElement;
            XmlNodeList entryList = root.SelectNodes("/entry_list/entry", nsmgr);
            XmlNode entry = entryList[0];

            try
            {
                word = entry.InnerXml.Split(new string[] { "<ew" }, StringSplitOptions.None)[1].Split(new string[] { "</ew" }, StringSplitOptions.None)[0].Trim()
                    .Replace("<fw>", "").Replace("</fw>", "").Replace("<sx>", "").Replace("</sx>", "")
                    .Replace("<vi>", "").Replace("</vi>", "").Replace("<it>", "").Replace("</it>", "")
                    .Replace(">", "")
                    .Replace("hindex=\"1\"", "").Replace("hindex=\"2\"", "")
                    .Replace("hindex=\"3\"", "").Replace("hindex=\"4\"", "")
                    .Replace("hindex=\"5\"", "").Replace("hindex=\"6\"", "");
                word = word.First().ToString().ToUpper() + word.Substring(1);
            }
            catch (Exception) { word = "-empty-"; }

            try
            {
                pronounce = entry.InnerXml.Split(new string[] { "<hw" }, StringSplitOptions.None)[1].Split(new string[] { "</hw" }, StringSplitOptions.None)[0].Trim()
                    .Replace("<fw>", "").Replace("</fw>", "").Replace("<sx>", "").Replace("</sx>", "")
                    .Replace("<vi>", "").Replace("</vi>", "").Replace("<it>", "").Replace("</it>", "")
                    .Replace(">", "")
                    .Replace("hindex=\"1\"", "").Replace("hindex=\"2\"", "")
                    .Replace("hindex=\"3\"", "").Replace("hindex=\"4\"", "")
                    .Replace("hindex=\"5\"", "").Replace("hindex=\"6\"", "");
                pronounce = pronounce.First().ToString().ToUpper() + pronounce.Substring(1);
            }
            catch (Exception) { pronounce = "-empty-"; }

            try
            {
                nounVerbAdj = entry.InnerXml.Split(new string[] { "<fl" }, StringSplitOptions.None)[1].Split(new string[] { "</fl" }, StringSplitOptions.None)[0].Trim()
                    .Replace("<fw>", "").Replace("</fw>", "").Replace("<sx>", "").Replace("</sx>", "")
                    .Replace("<vi>", "").Replace("</vi>", "").Replace("<it>", "").Replace("</it>", "")
                    .Replace(">", "")
                    .Replace("hindex=\"1\"", "").Replace("hindex=\"2\"", "")
                    .Replace("hindex=\"3\"", "").Replace("hindex=\"4\"", "")
                    .Replace("hindex=\"5\"", "").Replace("hindex=\"6\"", "");
                nounVerbAdj = nounVerbAdj.Split(' ')[0];
                nounVerbAdj = nounVerbAdj.First().ToString().ToUpper() + nounVerbAdj.Substring(1);
            }
            catch (Exception) { nounVerbAdj = "-empty-"; }

            try
            {
                defOne = entry.InnerXml.Split(new string[] { "<dt" }, StringSplitOptions.None)[1].Split(new string[] { "</dt" }, StringSplitOptions.None)[0].Trim()
                    .Replace("<fw>", "").Replace("</fw>", "").Replace("<sx>", "").Replace("</sx>", "")
                    .Replace("<vi>", "").Replace("</vi>", "").Replace("<it>", "").Replace("</it>", "")
                    .Replace(">", "")
                    .Replace("hindex=\"1\"", "").Replace("hindex=\"2\"", "")
                    .Replace("hindex=\"3\"", "").Replace("hindex=\"4\"", "")
                    .Replace("hindex=\"5\"", "").Replace("hindex=\"6\"", "");
                defOne = defOne.First().ToString().ToUpper() + defOne.Substring(1);
            }
            catch (Exception) { defOne = "-empty-"; }

            try
            {
                defTwo = entry.InnerXml.Split(new string[] { "<dt" }, StringSplitOptions.None)[2].Split(new string[] { "</dt" }, StringSplitOptions.None)[0].Trim()
                    .Replace("<fw>", "").Replace("</fw>", "").Replace("<sx>", "").Replace("</sx>", "")
                    .Replace("<vi>", "").Replace("</vi>", "").Replace("<it>", "").Replace("</it>", "")
                    .Replace(">", "")
                    .Replace("hindex=\"1\"", "").Replace("hindex=\"2\"", "")
                    .Replace("hindex=\"3\"", "").Replace("hindex=\"4\"", "")
                    .Replace("hindex=\"5\"", "").Replace("hindex=\"6\"", "");
                defTwo = defTwo.First().ToString().ToUpper() + defTwo.Substring(1);
            }
            catch (Exception) { defOne = "-empty-"; }

            var wordData = new Tuple<string, string, string, string, string>(word, pronounce, nounVerbAdj, defOne, defTwo);

            return wordData;
        }
    }
}
