using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowKeys
{
    static class Keys
    {
        public static List<Key> All = new List<Key>();
        public static Dictionary<int, Key> ByKeyCode = new Dictionary<int, Key>();
        public static float Width = 0;
        public static float Height = 0;
        static float _x = 0;
        static float _y = 0;

        static void AddRow(float height = 1)
        {
            _x = 0;
            _y += height;
        }

        static void AddKey(string? key, int vk = 0, float width = 1, float height = 1, string? name = null, int alt_vk = 0)
        {
            var temp = new Key
            {
                Desc = key,
                X = _x,
                Y = _y,
                Width = width,
                Height = height,
                VK = vk,
                AltVK = alt_vk,
                Name = name,
            };
            if (vk > 0)
            {
                if (ByKeyCode.ContainsKey(vk))
                {
                    throw new Exception($"Key Code of {vk} was already used!");
                }
                ByKeyCode[vk] = temp;
            }
            if (alt_vk > 0)
            {
                if (ByKeyCode.ContainsKey(alt_vk))
                {
                    throw new Exception($"Alt Key Code of {vk} was already used!");
                }
                ByKeyCode[alt_vk] = temp;
            }
            All.Add(temp);
            Width = Math.Max(Width, _x + width);
            Height = Math.Max(Height, _y + height);
            _x += width;
        }

        public static void Init()
        {
            AddKey("Esc", 27, name: "Escape");
            AddKey(null);
            AddKey("F1", 112);
            AddKey("F2", 113);
            AddKey("F3", 114);
            AddKey("F4", 115);
            AddKey(null, width: 0.5f);
            AddKey("F5", 116);
            AddKey("F6", 117);
            AddKey("F7", 118);
            AddKey("F8", 119);
            AddKey(null, width: 0.5f);
            AddKey("F9", 120);
            AddKey("F10", 121);
            AddKey("F11", 122);
            AddKey("F12", 123);
            AddRow(1.5f);

            AddKey("`", 192, name: "Backtick");
            AddKey("1", 49);
            AddKey("2", 50);
            AddKey("3", 51);
            AddKey("4", 52);
            AddKey("5", 53);
            AddKey("6", 54);
            AddKey("7", 55);
            AddKey("8", 56);
            AddKey("9", 57);
            AddKey("0", 48);
            AddKey("-", 189, name: "Minus");
            AddKey("=", 187, name: "Equals");
            AddKey("Back", 8, width: 2f, name: "Backspace");
            AddKey(null, width: 0.25f);
            AddKey("ins", 45 | 32768, name: "Insert");
            AddKey("home", 36 | 32768, name: "Home");
            AddKey("pgup", 33 | 32768, name: "Page Up");
            AddKey(null, width: 0.25f);
            AddKey("num", 144 | 32768, name: "Num Lock");
            AddKey("/", 111 | 32768, name: "Num Slash");
            AddKey("*", 106, name: "Num Multiply"); // TODO
            AddKey("-", 109, name: "Num Minus");
            AddRow();

            AddKey("Tab", 9, width: 1.5f);
            AddKey("q", 81);
            AddKey("w", 87);
            AddKey("e", 69);
            AddKey("r", 82);
            AddKey("t", 84);
            AddKey("y", 89);
            AddKey("u", 85);
            AddKey("i", 73);
            AddKey("o", 79);
            AddKey("p", 80);
            AddKey("[", 219);
            AddKey("]", 221);
            AddKey("\\", 220, width: 1.5f, name: "Backslash");
            AddKey(null, width: 0.25f);
            AddKey("del", 46 | 32768, name: "Delete");
            AddKey("end", 35 | 32768, name: "End");
            AddKey("pgdn", 34 | 32768, name: "Page Down");
            AddKey(null, width: 0.25f);
            AddKey("7", 103, name: "Num 7", alt_vk: 36);
            AddKey("8", 104, name: "Num 8", alt_vk: 38);
            AddKey("9", 105, name: "Num 9", alt_vk: 33);
            AddKey("+", 107, height: 2f, name: "Num Plus");
            AddRow();

            AddKey("Cap", 20, width: 2f, name: "Caps Lock");
            AddKey("a", 65);
            AddKey("s", 83);
            AddKey("d", 68);
            AddKey("f", 70);
            AddKey("g", 71);
            AddKey("h", 72);
            AddKey("j", 74);
            AddKey("k", 75);
            AddKey("l", 76);
            AddKey(";", 186, name: "Semicolon");
            AddKey("'", 222, name: "Apostrophe");
            AddKey("<-/", 13, width: 2f, name: "Enter");

            AddKey(null, width: 0.25f);
            AddKey(null);
            AddKey(null);
            AddKey(null);
            AddKey(null, width: 0.25f);
            AddKey("4", 100, name: "Num 4", alt_vk: 37);
            AddKey("5", 101, name: "Num 5", alt_vk: 12);
            AddKey("6", 102, name: "Num 6", alt_vk: 39);
            AddRow();

            AddKey("Shift", 160, width: 2.5f, name: "Left Shift");
            AddKey("z", 90);
            AddKey("x", 88);
            AddKey("c", 67);
            AddKey("v", 86);
            AddKey("b", 66);
            AddKey("n", 78);
            AddKey("m", 77);
            AddKey(",", 188, name: "Comma");
            AddKey(".", 190, name: "Period");
            AddKey("/", 191, name: "Slash");
            AddKey("Shift", 32929, width: 2.5f, name: "Right Shift");

            AddKey(null, width: 0.25f);
            AddKey(null);
            AddKey("up", 38 | 32768, name: "Up Arrow");
            AddKey(null);
            AddKey(null, width: 0.25f);
            AddKey("1", 97, name: "Num 1", alt_vk: 35);
            AddKey("2", 98, name: "Num 2", alt_vk: 40);
            AddKey("3", 99, name: "Num 3", alt_vk: 34);
            AddKey("<-/", 13 | 32768, height: 2f, name: "Num Enter");

            AddRow();

            AddKey("Ctrl", 162, width: 1.25f, name: "Left Control");
            AddKey("Win", 32859, width: 1.25f, name: "Left Windows");
            AddKey("Alt", 164, width: 1.25f, name: "Left Alt");
            AddKey("[Space]", 32, width: 6.25f, name: "Space Bar");
            AddKey("Alt", 32933, width: 1.25f, name: "Right Alt");
            AddKey("Win", 32860, width: 1.25f, name: "Right Windows");
            AddKey("Fn", -1, width: 1.25f, name: "Function Key");
            AddKey("Ctrl", 32931, width: 1.25f, name: "Right Control");

            AddKey(null, width: 0.25f);
            AddKey("left", 37 | 32768, name: "Left Arrow");
            AddKey("down", 40 | 32768, name: "Down Arrow");
            AddKey("right", 39 | 32768, name: "Right Arrow");
            AddKey(null, width: 0.25f);
            AddKey("0", 96, width: 2f, name: "Num 0", alt_vk: 45);
            AddKey(".", 110, name: "Num Period", alt_vk: 46);

            Width += 1f;
            Height += 1f;
            foreach (var key in All)
            {
                key.X += 0.5f;
                key.Y += 0.5f;
            }
        }
    }

    class Key
    {
        public string? Desc;
        public string? Name;
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public int VK;
        public int AltVK;
    }
}
