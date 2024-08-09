## Use WinForms as WebSocket Server
![image](https://github.com/user-attachments/assets/72bae2c4-1ef7-4294-aa3b-00bc9e286ff8)

## Example Code
```cs
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
```

# Windows Forms App (.NET Framework)
I'm using WebSocketSharp as WebSocket Server that can receive and send message back to Client (React).
- nuget install command: `Install-Package WebSocketSharp -Version 1.0.3-rc11`

# Which Project Type that I use
![image](https://github.com/user-attachments/assets/29ccb191-68b5-44fa-8d69-98c7042ee020)

![image](https://github.com/user-attachments/assets/f64f6458-47c5-41e1-8305-d509849d3a92)
