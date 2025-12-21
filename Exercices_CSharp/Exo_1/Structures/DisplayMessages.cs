using System;
using System.Collections.Generic;
using System.Text;
using Exo_1.Enums;

namespace Exo_1.Structures
{
    public struct DisplayMessages
    {
        public string Result(Enum message)
        {

            switch(message)
            {
                case Messages.AMOUNT_SUP_ZERO:
                    Console.WriteLine("\"Le montant doit-être supérieur à 0\"");
                    break;
                default:
                    Console.WriteLine("\nJe ne comprends pas les données\n");
                    break;
            }
        }
    }
}
