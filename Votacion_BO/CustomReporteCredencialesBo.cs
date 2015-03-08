//===============================================
//Autor: Hernan Dario Betancur Cardenas
//Todos los derechos reservados
//Fecha:23/11/2013
//===============================================
//using Microsoft.Reporting.WebForms;
//using System.Net;
//using System.Security.Principal;

//namespace Votacion_BO
//{
//    public class CustomReportCredentials : IReportServerCredentials
//    {
//        private readonly string _DomainName;
//        private readonly string _PassWord;
//        private readonly string _UserName;

//        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
//        {
//            _UserName = UserName;
//            _PassWord = PassWord;
//            _DomainName = DomainName;
//        }


//        public WindowsIdentity ImpersonationUser
//        {
//            get { return null;}
//        }

//        public ICredentials NetworkCredentials
//        {
//            get
//            {
//                return new NetworkCredential(_UserName, _PassWord, _DomainName);
//            }
//        }

//        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password,
//                                        out string authority)
//        {
//            authCookie = null;
//            user = password = authority = null;
//            return false;
//        }
//    }
//}
