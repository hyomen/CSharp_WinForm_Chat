using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace chattingServer
{
    public partial class ChatServerForm : Form
    {
        public string bufferedList;
        public List<string> users = new List<string>();
        TcpListener server;
        public void AddText(string text)
        {
            myConsole.AppendText(text);
            myConsole.Select(myConsole.Text.Length, 0);
            myConsole.ScrollToCaret();
        }
        void ControlEnter(object sender, EventArgs e)
        {
            string input = ControlInput.Text;
            Controller(input);
            ControlInput.Text = string.Empty;
            ControlInput.Focus();
        }
        void RefreshChatters()
        {
            CheckForIllegalCrossThreadCalls = false;
            while (true)
            {
                bufferedList = "**userlist** ";
                ClientList.Items.Clear();   
                foreach(string user in users)
                {
                    ClientList.Items.Add(user);
                    bufferedList += (user+" ");
                }
                Thread.Sleep(1000);
            }
        }
        void OpenServer(object s)
        {
            string serverIP = s.ToString().Substring("/open ".Length);
            TcpClient client = new TcpClient();
            const int Port = 10203;
            IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(serverIP), Port);
            server = new TcpListener(serverAddr);
            try
            {
                server.Start();
            }
            catch (SocketException e)
            {
                MessageBox.Show("올바르지 않은 주소입니다.");
                return;
            }
            AddText(String.Format("Server Opened. [{0}]\r\n", serverAddr.ToString()));
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string userID = Encoding.Default.GetString(buffer, 0, bytes);
                    users.Add(userID);
                    MyChatServer mychat = new MyChatServer(client, userID, this);
                    Thread serverThread = new Thread(new ThreadStart(mychat.Listen));
                    serverThread.IsBackground = true;
                    serverThread.Start();
                }
                catch (Exception e) { break; }
            }
            client.Close();
            server.Stop();
        }
        void CloseServer()
        {
            // 서버 닫는 처리
        }
        void Controller(string s)
        {
            if (s.Equals(string.Empty)) return;
            else if(s.Equals("/close"))
            {
                CloseServer();
                AddText("[Server] Closed.\r\n");
            }
            else if (s.StartsWith("/open "))
            {
                Thread open = new Thread(OpenServer);
                open.IsBackground = true;
                open.Start(s);
            }
        }
        public ChatServerForm()
        {
            InitializeComponent();
        }
        private void ControlInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ControlEnter(sender, e);
        }

        private void ChatServerForm_Load(object sender, EventArgs e)
        {
            Thread refresher = new Thread(RefreshChatters);
            refresher.IsBackground = true;
            refresher.Start(); 
        }
    }
}


/*
 * 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace chattingServer
{
    public partial class ChatServerForm : Form
    {
        public string bufferedList;
        public List<string> spams = new List<string>();
        public List<string> bans = new List<string>();
        public List<string> users = new List<string>();
        TcpListener server;
        public void AddText(string text)
        {
            myConsole.AppendText(text);
            myConsole.Select(myConsole.Text.Length, 0);
            myConsole.ScrollToCaret();
        }
        void ControlEnter(object sender, EventArgs e)
        {
            string input = ControlInput.Text;
            Controller(input);
            ControlInput.Text = string.Empty;
            ControlInput.Focus();
        }
        void RefreshChatters()
        {
            CheckForIllegalCrossThreadCalls = false;
            while (true)
            {
                bufferedList = "**userlist** ";
                ClientList.Items.Clear();   
                foreach(string user in users)
                {
                    ClientList.Items.Add(user);
                    bufferedList += (user+" ");
                }
                Thread.Sleep(1000);
            }
        }
        void OpenServer(object s)
        {
            string serverIP = s.ToString().Substring("/open ".Length);
            TcpClient client = new TcpClient();
            const int Port = 10203;
            IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(serverIP), Port);
            server = new TcpListener(serverAddr);
            try
            {
                server.Start();
            }
            catch(SocketException e)
            {
                MessageBox.Show("올바르지 않은 주소입니다.");
                return;
            }
            AddText(String.Format("Server Opened. [{0}]\r\n", serverAddr.ToString()));
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string userID = Encoding.Default.GetString(buffer, 0, bytes);
                    users.Add(userID);
                    MyChatServer mychat = new MyChatServer(client, userID, this);
                    Thread serverThread = new Thread(new ThreadStart(mychat.Listen));
                    serverThread.IsBackground = true;
                    serverThread.Start();
                }
                catch (Exception e) { break; }
            }
            client.Close();
            server.Stop();
        }
        void CloseServer()
        {
            // 서버 닫는 처리
        }
        void Controller(string s)
        {
            if (s.Equals(string.Empty)) return;
            else if(s.Equals("/close"))
            {
                CloseServer();
                AddText("[Server] Closed.\r\n");
            }
            else if (s.StartsWith("/open "))
            {
                Thread open = new Thread(OpenServer);
                open.IsBackground = true;
                open.Start(s);
            }
            else if (s.Equals("/spamlist"))
            {
                AddText("금지어 목록은 아래와 같습니다.\r\n");
                foreach (string spam in spams) AddText(spam + "\r\n");
                AddText("=======================\r\n");
            }
            else if (s.StartsWith("/spam "))
            {
                string spam = s.Substring("/spam ".Length);
                if (spams.Contains(spam))
                {
                    AddText(string.Format("[Server] Spam {0} is already banned.\r\n", spam));
                }
                else
                {
                    spams.Add(spam);
                    AddText(string.Format("[Server] Spam {0} Added.\r\n", spam));
                }
            }
            else if (s.StartsWith("/unspam "))
            {
                string unspam = s.Substring("/unspam ".Length);
                if (spams.Remove(unspam))
                {
                    AddText(string.Format("[Server] Spam {0} deleted.\r\n", unspam));
                }
                else
                {
                    AddText(string.Format("[Server] {0} is not banned.\r\n", unspam));
                }
            }
            else if (s.StartsWith("/ban "))
            {
                string ID = s.Substring("/ban ".Length);
                bans.Add(ID);
                AddText(string.Format("[Server] Ban : {0} \r\n", ID));
            }
        }
        public ChatServerForm()
        {
            InitializeComponent();
        }
        private void ControlInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ControlEnter(sender, e);
        }

        private void ChatServerForm_Load(object sender, EventArgs e)
        {
            Thread refresher = new Thread(RefreshChatters);
            refresher.IsBackground = true;
            refresher.Start(); 
        }
    }
}

 *
 * 
 * */
