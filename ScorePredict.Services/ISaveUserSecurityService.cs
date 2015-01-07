using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Data;

namespace ScorePredict.Services
{
    public interface ISaveUserSecurityService
    {
        void SaveUser(User user);
    }
}
