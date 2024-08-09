using System;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private WebSocketServer wss;

        public Form1()
        {
            InitializeComponent();
            wss = new WebSocketServer("ws://localhost:8080");
            wss.AddWebSocketService<ChatBehavior>("/");

            wss.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            wss.Stop();
            base.OnFormClosed(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class ChatBehavior : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Form1 form = Application.OpenForms[0] as Form1;
                form.Invoke(new Action(() =>
                {
                    form.textBox1.AppendText(e.Data + Environment.NewLine);
                }));

                Send("Server received: " + e.Data);
            }
        }
    }
}
