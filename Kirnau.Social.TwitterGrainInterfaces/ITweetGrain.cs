﻿//*********************************************************//
//    Copyright (c) Microsoft. All rights reserved.
//    
//    Apache 2.0 License
//    
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    
//    Unless required by applicable law or agreed to in writing, software 
//    distributed under the License is distributed on an "AS IS" BASIS, 
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or 
//    implied. See the License for the specific language governing 
//    permissions and limitations under the License.
//
//*********************************************************

using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;

namespace Kirnau.Social.TwitterGrainInterfaces
{
    /// <summary>
    /// A grain to act as the API into Orleans, and fan out read/writes to multiple hashtag grains
    /// </summary>
    public interface ITweetDispatcherGrain : Orleans.IGrain
    {
        Task AddScore(int score, string[] hashtags, string tweet);

        Task<Totals[]> GetTotals(string[] hashtags);
    }
}
