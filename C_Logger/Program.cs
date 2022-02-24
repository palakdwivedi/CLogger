using System;
using System.IO;

namespace myos
{
    public abstract class OurBaseClass{
        public abstract void Log(string Messsage);
    }

    public class OurUser: OurBaseClass{

        private String RecentFile
        {
            get;
            set;
        }

        private String FileName{
            get;
            set;
        }

        private String FilePath {
            get;
            set;
        }

        public OurUser()
        {
            this.RecentFile = Directory.GetCurrentDirectory();
            this.FileName = "Palak.txt";
            this.FilePath = this.RecentFile + "/"  + this.FileName;
        
        }

        public override void Log(string Messsage)
        {
           
            System.Console.WriteLine("The user is Logged : {0}", Messsage);

            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("  :{0}", Messsage);
                w.WriteLine("-----------------------------------------------");
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            var logger = new OurUser();
            logger.Log("Palak Dwivedi");
            Console.ReadLine();
        }
    }
}