using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowKeys
{
    static class Counts
    {
        public static Dictionary<int, int> VkCounts = new Dictionary<int, int>();
        static int _hits = 0;
        static KeyForm? _parent = null;

        public static void Init(KeyForm parent)
        {
            _parent = parent;

            if (File.Exists("counts.txt"))
            {
                foreach (var line in File.ReadLines("counts.txt"))
                {
                    var kvp = line.Split(',');
                    VkCounts[int.Parse(kvp[0])] = int.Parse(kvp[1]);
                }
            }
        }

        public static void Save()
        {
            if (_hits > 0)
            {
                _hits = 0;
                StringBuilder sb = new StringBuilder();
                foreach (var kvp in VkCounts)
                {
                    sb.Append($"{kvp.Key},{kvp.Value}\n");
                }
                File.WriteAllText("counts.txt", sb.ToString());
            }
        }

        public static void AddVK(int vk)
        {
            _hits++;
            if (VkCounts.ContainsKey(vk))
            {
                VkCounts[vk]++;
            }
            else
            {
                VkCounts[vk] = 1;
            }

            if (_hits > 25)
            {
                Save();
            }

            if (_parent != null)
            {
                _parent.UpdateKeyboard();
            }
        }
    }
}
