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
    public partial class DebugOutputPanel : UserControl
    {
        public DebugOutputPanel()
        {
            InitializeComponent();
            Debug.Listeners.Add(new SimpleTraceListener(this.textBox1));
        }
    }

    public class SimpleTraceListener:TraceListener
    {
        public SimpleTraceListener(TextBox tb)
        {
            _textBox = tb;
        }
        TextBox _textBox;
        public override void Write(string message)
        {
            _textBox.Text = _textBox.Text + message;
        }

        public override void WriteLine(string message)
        {
            _textBox.Text = _textBox.Text + message + Environment.NewLine;
        }
    }
}
