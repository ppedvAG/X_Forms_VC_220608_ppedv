using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    public interface IToastService
    {
        void ShowLongToast(string msg);

        void ShowShortToast(string msg);
    }
}
