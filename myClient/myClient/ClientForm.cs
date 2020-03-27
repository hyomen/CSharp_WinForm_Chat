using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace myClient
{
    public partial class ClientForm : Form
    {
        string ID;
        NetworkStream stream = default(NetworkStream);
        TcpClient client = new TcpClient();
        public ClientForm(string ID)
        {
            this.ID = ID;
            InitializeComponent();
        }
        void Connect(string s)
        {
            char split = ' ';
            string[] parsedIP = s.Split(split); // 1 : client, 2 : server, 3 : server Port
            
            try
            {
                IPEndPoint clientAddr = new IPEndPoint(IPAddress.Parse(parsedIP[1]), 0);
                IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(parsedIP[2]), Int32.Parse(parsedIP[3]));
                client = new TcpClient(clientAddr);
                client.Connect(serverAddr);
                stream = client.GetStream();
                Display("Chat Server Connected...");
            }
            catch(Exception e)
            {
                Display("Failed to Connect...");
            }
            if(!client.Connected)
            {
                MessageBox.Show("usage : /connect 클라이언트IP 서버IP 서버PORT");
                InputField.Text = string.Empty;
                InputField.Focus();
            }
            else
            {
                byte[] buffer = Encoding.Default.GetBytes(ID);
                stream.Write(buffer, 0, buffer.Length);

                Thread clientThread = new Thread(Receiver);
                clientThread.IsBackground = true;
                clientThread.Start();
            }
            
        }
        void Display(string msg)
        {
            CheckForIllegalCrossThreadCalls = false;
            ChatLog.AppendText(msg+"\r\n");
            ChatLog.Select(ChatLog.Text.Length, 0);
            ChatLog.ScrollToCaret();
        }
        void Receiver()
        {
            try
            {
                while (true)
                {
                    int bufferSize = client.ReceiveBufferSize;
                    byte[] buffer = new byte[bufferSize];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string msg = Encoding.Default.GetString(buffer, 0, bytes);
                    if(!isControlMsg(msg)) Display(msg);
                }
            }
            catch(IOException e)
            {
                //
            }
        }
        bool isControlMsg(string msg)
        {
            bool isCtrl = true;
            if (msg.StartsWith("**userlist** "))
            {
                ChatterList.Items.Clear();
                char split = ' ';
                string[] userlist = msg.Split(split);
                foreach(string s in userlist)
                {
                    if (s.StartsWith("**")) continue;
                    ChatterList.Items.Add(s);
                }
            }
            else isCtrl = false;
            return isCtrl;
        }
        void RefreshUserlist(string[] ul)
        {

        }
        void Sender(string s)
        {
            byte[] buffer = Encoding.Default.GetBytes(s);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
        void Controller(string s)
        {
            if(s.StartsWith("/connect "))
            {
                Connect(s);
            }
            else if(!client.Connected)
            {
                MessageBox.Show("서버에 먼저 연결해주세요.");
                InputField.Text = string.Empty;
                InputField.Focus();
            }
            else if(s.Equals("/exit"))
            {
                Disconnect();
            }
            else
            {
                Sender(s);
            }
        }
        void Disconnect()
        {
            byte[] buffer = Encoding.Default.GetBytes("/exit");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            stream.Close();
            client.Close();
            Application.ExitThread();
            this.Close();
        }
        void Disconnect(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("/exit");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            stream.Close();
            client.Close();
            Application.ExitThread();
            this.Close();
        }
        private void InputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) EnterBtn_Click(sender, e);
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            string input = InputField.Text;
            Controller(input);
            InputField.Text = string.Empty;
            InputField.Focus();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
