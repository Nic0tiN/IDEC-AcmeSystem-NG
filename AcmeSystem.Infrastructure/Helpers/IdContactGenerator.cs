using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Infrastructure.Helpers
{
    public class IdContactGenerator
    {
        private static int _nextId = 100;

        public static int GetNext()
        {
            return ++_nextId;
        }
    }
}
