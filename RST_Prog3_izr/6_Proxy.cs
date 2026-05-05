using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RST_Prog3_izr
{
    // Primer za varnostni proxy

    public interface IInternet
    {
        void ConnectTo(string url);
    }

    public class InternetConnector : IInternet
    {
        public void ConnectTo(string url)
        {
            Console.WriteLine($"Povezava na {url} je uspešno vzpostavljena!");
        }
    }

    public class OfficeInternetProxy : IInternet
    {
        private readonly InternetConnector internetConnector = new InternetConnector();

        private static readonly List<string> lstBannedSites = new() { "facebook.com", "gamble.com" };

        public void ConnectTo(string url) 
        {
            // Preverimo url
            if (lstBannedSites.Contains(url.ToLower()))
            {
                Console.WriteLine($"Dostop na {url} je zavrnjen zaradi politike podjetja!");
                return;
            }

            // Zabeležimo dogodek
            Console.WriteLine($"LOG: Uporabnik se poskuša povezati na {url}.");

            // Uporabimo instanco osnovnega razreda
            this.internetConnector.ConnectTo(url);
        }
    }


    // Primer za virtualni proxy

    public interface IPost
    {
        void ShowPost();
    }

    public class RealPost : IPost
    {
        private string imageUrl;

        public RealPost(string imgUrl)
        {
            this.imageUrl = imgUrl;
            DownloadImage();
        }

        public void ShowPost()
        {
            Console.WriteLine($"Prikazujemo fotografijo iz {this.imageUrl}");
        }

        private void DownloadImage()
        {
            Console.WriteLine($"Prenašamo veliiiko podatkov iz {this.imageUrl}");
            Thread.Sleep(3000);
        }
    }

    public class PostProxy : IPost
    {
        private RealPost? realPost;
        private string imageUrl;

        public PostProxy(string imgUrl)
        {
            this.imageUrl = imgUrl;
        }

        public void ShowPost()
        {
            if(this.realPost == null)
            {
                this.realPost = new RealPost("img.com");
            }
            this.realPost.ShowPost();
        }
    }
}
