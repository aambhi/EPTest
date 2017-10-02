using DemoTest.Core.Model;
using System.Collections;
using System.Collections.Generic;

namespace DemoTest.Core.RepositoryInterface
{
    public interface IProfile
    {
        bool Create(Profile profile);
        List<IEnumerable> GetMasterData();
    }
}
