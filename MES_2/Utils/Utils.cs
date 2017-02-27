//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-01-29
//  ===============================
//  Namespace        : MES_application
//  Class                   : Utils.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-01-29
//  Change History: 
// 
// ==================================
using System;
using System.Collections.Generic;
using System.Text;
using Sharp7;


namespace MES_application.Utils
{

    public static class Utils
    {

        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// Hexdumps the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        /// TODO http://stackoverflow.com/questions/26206257/packet-dump-hex-view-format-for-byte-to-text-file
        public static string hexdump(byte[] bytes, int size)
        {
            if (bytes == null)
                return "";
            var bytesLength = size;
            var bytesPerLine = 16;

            var hexchars = "0123456789ABCDEF".ToCharArray();

            var firstHexColumn =
                8 // 8 characters for the address
                + 3; // 3 spaces

            var firstCharColumn = firstHexColumn
                                  + bytesPerLine * 3 // - 2 digit for the hexadecimal value and 1 space
                                  + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                                  + 2; // 2 spaces 

            var lineLength = firstCharColumn
                             + bytesPerLine // - characters to show the ascii value
                             + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            var line = (new string(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            var expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            var result = new StringBuilder(expectedLines * lineLength);

            for (var i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = hexchars[(i >> 28) & 0xF];
                line[1] = hexchars[(i >> 24) & 0xF];
                line[2] = hexchars[(i >> 20) & 0xF];
                line[3] = hexchars[(i >> 16) & 0xF];
                line[4] = hexchars[(i >> 12) & 0xF];
                line[5] = hexchars[(i >> 8) & 0xF];
                line[6] = hexchars[(i >> 4) & 0xF];
                line[7] = hexchars[(i >> 0) & 0xF];

                var hexColumn = firstHexColumn;
                var charColumn = firstCharColumn;

                for (var j = 0; j < bytesPerLine; j++)
                {
                    if ((j > 0) && ((j & 7) == 0))
                        hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        var b = bytes[i + j];
                        line[hexColumn] = hexchars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = hexchars[b & 0xF];
                        line[charColumn] = b < 32 ? '·' : (char)b;
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }
    }
}