using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LusongControl
{
    public partial class ConsoleOutputPanel : UserControl
    {
        public ConsoleOutputPanel()
        {
            InitializeComponent();
            Console.SetOut(new SimpleTextWrite(this.textBox1));
        }
    }
    // TextWriter作为Console.Out的接收对象
    // SimpleTextWrite作为接收到TextBox的TexWriter。
    public class SimpleTextWrite : TextWriter
    {
        public SimpleTextWrite(TextBox tb)
        {
            _textBox = tb;
        }
        TextBox _textBox;
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        #region Write
        //
        // 摘要:
        //     Writes the text representation of a Boolean value to the text stream.
        //
        // 参数:
        //   value:
        //     The Boolean to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(bool value)
        {
            Write(value.ToString());
        }
        //
        // 摘要:
        //     Writes a character to the text stream.
        //
        // 参数:
        //   value:
        //     The character to write to the text stream.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(char value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes a character array to the text stream.
        //
        // 参数:
        //   buffer:
        //     The character array to write to the text stream.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(char[] buffer) { Write(buffer.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of a decimal value to the text stream.
        //
        // 参数:
        //   value:
        //     The decimal value to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(decimal value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of an 8-byte floating-point value to the text
        //     stream.
        //
        // 参数:
        //   value:
        //     The 8-byte floating-point value to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(double value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of a 4-byte floating-point value to the text
        //     stream.
        //
        // 参数:
        //   value:
        //     The 4-byte floating-point value to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(float value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of a 4-byte signed integer to the text stream.
        //
        // 参数:
        //   value:
        //     The 4-byte signed integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(int value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of an 8-byte signed integer to the text stream.
        //
        // 参数:
        //   value:
        //     The 8-byte signed integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(long value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of an object to the text stream by calling
        //     ToString on that object.
        //
        // 参数:
        //   value:
        //     The object to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(object value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes a string to the text stream.
        //
        // 参数:
        //   value:
        //     The string to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(string value)
        {
            this._textBox.Text = this._textBox.Text + value;
        }
        //
        // 摘要:
        //     Writes the text representation of a 4-byte unsigned integer to the text stream.
        //
        // 参数:
        //   value:
        //     The 4-byte unsigned integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public override void Write(uint value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes the text representation of an 8-byte unsigned integer to the text
        //     stream.
        //
        // 参数:
        //   value:
        //     The 8-byte unsigned integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public override void Write(ulong value) { Write(value.ToString()); }
        //
        // 摘要:
        //     Writes out a formatted string, using the same semantics as System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg0:
        //     An object to write into the formatted string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     the number of provided objects to be formatted.
        public override void Write(string format, object arg0) { Write(string.Format(format, arg0)); }
        //
        // 摘要:
        //     Writes out a formatted string, using the same semantics as System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg:
        //     The object array to write into the formatted string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format or arg is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     arg. Length.
        public override void Write(string format, params object[] arg) { Write(string.Format(format, arg)); }
        //
        // 摘要:
        //     Writes a subarray of characters to the text stream.
        //
        // 参数:
        //   buffer:
        //     The character array to write data from.
        //
        //   index:
        //     Starting index in the buffer.
        //
        //   count:
        //     The number of characters to write.
        //
        // 异常:
        //   System.ArgumentException:
        //     The buffer length minus index is less than count.
        //
        //   System.ArgumentNullException:
        //     The buffer parameter is null.
        //
        //   System.ArgumentOutOfRangeException:
        //     index or count is negative.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void Write(char[] buffer, int index, int count)
        {
            for (int i = 0; i < count; i++)
                Write(buffer[index + i].ToString());
        }
        //
        // 摘要:
        //     Writes out a formatted string, using the same semantics as System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg0:
        //     An object to write into the formatted string.
        //
        //   arg1:
        //     An object to write into the formatted string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     the number of provided objects to be formatted.
        public override void Write(string format, object arg0, object arg1) { Write(string.Format(format, arg0, arg1)); }
        //
        // 摘要:
        //     Writes out a formatted string, using the same semantics as System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg0:
        //     An object to write into the formatted string.
        //
        //   arg1:
        //     An object to write into the formatted string.
        //
        //   arg2:
        //     An object to write into the formatted string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     the number of provided objects to be formatted.
        public override void Write(string format, object arg0, object arg1, object arg2) { Write(string.Format(format, arg0, arg1, arg2)); }
        //
        // 摘要:
        //     Writes a line terminator to the text stream.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine() { Write(Environment.NewLine); }
        //
        // 摘要:
        //     Writes the text representation of a Boolean followed by a line terminator
        //     to the text stream.
        //
        // 参数:
        //   value:
        //     The Boolean to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(bool value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes a character followed by a line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The character to write to the text stream.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(char value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes an array of characters followed by a line terminator to the text stream.
        //
        // 参数:
        //   buffer:
        //     The character array from which data is read.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(char[] buffer) { Write(buffer); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of a decimal value followed by a line terminator
        //     to the text stream.
        //
        // 参数:
        //   value:
        //     The decimal value to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(decimal value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of a 8-byte floating-point value followed
        //     by a line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The 8-byte floating-point value to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(double value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of a 4-byte floating-point value followed
        //     by a line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The 4-byte floating-point value to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(float value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of a 4-byte signed integer followed by a line
        //     terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The 4-byte signed integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(int value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of an 8-byte signed integer followed by a
        //     line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The 8-byte signed integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(long value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of an object by calling ToString on this object,
        //     followed by a line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The object to write. If value is null, only the line termination characters
        //     are written.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(object value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes a string followed by a line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The string to write. If value is null, only the line termination characters
        //     are written.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(string value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of a 4-byte unsigned integer followed by a
        //     line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The 4-byte unsigned integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public override void WriteLine(uint value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes the text representation of an 8-byte unsigned integer followed by
        //     a line terminator to the text stream.
        //
        // 参数:
        //   value:
        //     The 8-byte unsigned integer to write.
        //
        // 异常:
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public override void WriteLine(ulong value) { Write(value); WriteLine(); }
        //
        // 摘要:
        //     Writes out a formatted string and a new line, using the same semantics as
        //     System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatted string.
        //
        //   arg0:
        //     The object to write into the formatted string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     the number of provided objects to be formatted.
        public override void WriteLine(string format, object arg0) { Write(format, arg0); WriteLine(); }
        //
        // 摘要:
        //     Writes out a formatted string and a new line, using the same semantics as
        //     System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg:
        //     The object array to write into format string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     A string or object is passed in as null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     arg.Length.
        public override void WriteLine(string format, params object[] arg) { Write(format, arg); WriteLine(); }
        //
        // 摘要:
        //     Writes a subarray of characters followed by a line terminator to the text
        //     stream.
        //
        // 参数:
        //   buffer:
        //     The character array from which data is read.
        //
        //   index:
        //     The index into buffer at which to begin reading.
        //
        //   count:
        //     The maximum number of characters to write.
        //
        // 异常:
        //   System.ArgumentException:
        //     The buffer length minus index is less than count.
        //
        //   System.ArgumentNullException:
        //     The buffer parameter is null.
        //
        //   System.ArgumentOutOfRangeException:
        //     index or count is negative.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        public override void WriteLine(char[] buffer, int index, int count) { Write(buffer, index, count); WriteLine(); }
        //
        // 摘要:
        //     Writes out a formatted string and a new line, using the same semantics as
        //     System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg0:
        //     The object to write into the format string.
        //
        //   arg1:
        //     The object to write into the format string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     the number of provided objects to be formatted.
        public override void WriteLine(string format, object arg0, object arg1) { Write(format, arg0, arg1); WriteLine(); }
        //
        // 摘要:
        //     Writes out a formatted string and a new line, using the same semantics as
        //     System.String.Format(System.String,System.Object).
        //
        // 参数:
        //   format:
        //     The formatting string.
        //
        //   arg0:
        //     The object to write into the format string.
        //
        //   arg1:
        //     The object to write into the format string.
        //
        //   arg2:
        //     The object to write into the format string.
        //
        // 异常:
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.ObjectDisposedException:
        //     The System.IO.TextWriter is closed.
        //
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.  -or- The number indicating
        //     an argument to be formatted is less than zero, or larger than or equal to
        //     the number of provided objects to be formatted.
        public override void WriteLine(string format, object arg0, object arg1, object arg2) { Write(format, arg0, arg1, arg2); WriteLine(); }
        #endregion
    }
}
