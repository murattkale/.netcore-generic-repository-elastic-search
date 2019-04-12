//using Facebook;
//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//public static class Social
//{

//    public static void FacebookShare(string id ,string _acccessToken, string _subject, string _caption, string _description, string _message, string _picture, string _link)
//    {

//        //paylaşım yapıdlıktan sonra, facebook post'un bileşenleridir olarak profil veya sayfada görünecek ögeler
//        //string subject = "eğitim, kodlama, paylaşım.";
//        //string caption = "eğitim, kodlama, paylaşım.";
//        //string description = "eğitim, kodlama, paylaşım.";
//        //string message = "facebook paylaşımı yapmak";
//        //string picture = "image.png";
//        //string link = "link";

//        //string acccessToken = "kendi_uygulamamızdan_aldığımız_access_token";

//        dynamic FacebookPost = new ExpandoObject();

//        //Referans olarak aldığımız Facebook kütüphanesini kullanıyoruz.
//        FacebookPost.picture = _picture;
//        FacebookPost.link = _link;
//        FacebookPost.name = _message;
//        FacebookPost.caption = _caption;
//        FacebookPost.description = _description;
//        FacebookPost.message = _message;

//        //Kütüphanenin servislerine, access token ile bağlanma işlemi yapılır.
//        FacebookClient appp = new FacebookClient(_acccessToken);

//        //Tanımlanan ve gerekli atamaları yapılan 'FacebookPost' nesnesi, 'appp' olarak tanımlanan veri gönderim
//        //servisi çalıştırılarak paylaşım yapma işlemi tamamlanır. 
//        var postId = appp.Post(id +"/feed", FacebookPost);
//    }


//}
