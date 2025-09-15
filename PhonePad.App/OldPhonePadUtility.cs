using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Turing.Phone
{
    /// <summary>
    /// Utility class to process old phone keypad input.
    /// </summary>
    public static class OldPhonePadUtility
    {
        private static readonly Dictionary<char, string> KEYPAD = new()
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };

        public static string Process(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var result = new StringBuilder();
            var buffer = new StringBuilder();

            foreach (var c in input)
            {
                switch (c)
                {
                    case '#':
                    case ' ':
                        FlushBuffer(result, buffer);
                        break;
                    case '*':
                        HandleBackspace(result, buffer);
                        break;
                    default:
                        if (char.IsDigit(c) && KEYPAD.ContainsKey(c))
                        {
                            HandleDigit(result, buffer, c);
                        }
                        break;
                }
            }

            return result.ToString();
        }

        private static void HandleBackspace(StringBuilder result, StringBuilder buffer)
        {
            FlushBuffer(result, buffer);
            if (result.Length > 0)
            {
                result.Remove(result.Length - 1, 1);
            }
        }

        private static void HandleDigit(StringBuilder result, StringBuilder buffer, char c)
        {
            if (buffer.Length > 0 && buffer[0] != c)
            {
                FlushBuffer(result, buffer);
            }
            buffer.Append(c);
        }

        private static void FlushBuffer(StringBuilder result, StringBuilder buffer)
        {
            if (buffer.Length == 0)
                return;

            char key = buffer[0];
            int count = buffer.Length;
            string letters = KEYPAD[key];
            char letter = letters[(count - 1) % letters.Length];
            result.Append(letter);

            buffer.Clear();
        }
    }
}
