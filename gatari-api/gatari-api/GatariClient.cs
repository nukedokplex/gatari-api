using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gatari_api
{
    class GatariClient
    {
        GatariUserStats GetUserStats(string user)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://osu.gatari.pw/api/v1/users/stats?u=" + user);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            String sourceJSON = response.GetResponseStream().ToString();
            GatariUserStatsResponse res = JsonConvert.DeserializeObject<GatariUserStatsResponse>(sourceJSON);
            if (res.code == 200)
            {
                return res.stats;
            }
            else
            {
                throw new Exception("Gatari server returned invalid response code... WTF???");
            }
        }
    }
}
