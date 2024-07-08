using Dal;
using Dal.DalImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplementaion;

public class InfoService
{
    InfoRepo _repo;
    public InfoService(DalManager manager)
    {
        this._repo = manager.info;
    }
    public List<string> GetChallenges()
    {
        var challenges = new List<string>();
        var res = _repo.GetChallenges();
        foreach (var challenge in res)
        {
            challenges.Add(challenge.Challenge);
        }
        return challenges;
    }
}
