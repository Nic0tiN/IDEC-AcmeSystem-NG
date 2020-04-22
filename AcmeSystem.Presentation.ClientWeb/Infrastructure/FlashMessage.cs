using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AcmeSystem.Presentation.ClientWeb.Infrastructure
{

    public static class FlashMessage
    {
        public enum FlashType { Success, Danger };

        public static FlashType Type { get; private set; }
        private static string _message = "";

        public static void Success(string message)
        {
            Type = FlashType.Success;
            _message = message;
        }

        public static void Error(string message)
        {
            Type = FlashType.Danger;
            _message = message;
        }

        public static bool HasError() => Type == FlashType.Danger && HasMessage();
        public static bool HasSuccess() => Type == FlashType.Success && HasMessage();
        public static bool HasMessage() => _message.Length > 0;

        public static string Message
        {
            get
            {
                string output = _message.ToString();
                _message = "";

                return output;
            }
        }
    }
}
