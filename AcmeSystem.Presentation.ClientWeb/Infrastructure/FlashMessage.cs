using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AcmeSystem.Presentation.ClientWeb.Infrastructure
{

    public static class FlashMessage
    {
        public enum FlashType { success, danger };

        public static FlashType Type { get; private set; }
        private static string _message = "";

        public static void Success(string message)
        {
            Type = FlashType.success;
            _message = message;
        }

        public static void Error(string message)
        {
            Type = FlashType.danger;
            _message = message;
        }

        public static bool HasError() => Type == FlashType.danger && HasMessage();
        public static bool HasSuccess() => Type == FlashType.success && HasMessage();
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
