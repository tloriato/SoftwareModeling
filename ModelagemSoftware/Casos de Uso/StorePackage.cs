using System;
using System.Collections.Generic;
using System.Text;

namespace ModelagemSoftware.Casos_de_Uso
{
    class StorePackage
    {
        public StorePackage(Storage storage, Worker worker)
        {

        }

    }
}

/*
    1. Worker requests from the System list of pending items to be stored.
    2. System displays all items pending storage.
    3. Worker identifies which item(s) he would like to store at that moment.
    4. System verifies that some item(s) was/were selected and ask user to confirm.
    5. Worker confirms the creation of a storage order.
    6. System reports to user the location(s) where each item should be stored into the facility.
 */
