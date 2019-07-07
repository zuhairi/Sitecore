using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamedPipeWrapper;
using Console = System.Console;

namespace WindowsPublishSubscribe
{
    public class Server
    {
        private string _pipelineName;

        private NamedPipeServer<string> _server;
        private string _userInput;
        private bool KeepRunning
        {
            get
            {  
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                    return false;
                return true;
            }
        }
        public Server(string pipelineName= "DefaultPipelineName")
        {
            if (pipelineName != "") _pipelineName = pipelineName;

            _server = new NamedPipeServer<string>(_pipelineName);
            _server.ClientConnected += OnClientConnected;
            _server.ClientDisconnected += OnClientDisconnected;
            _server.ClientMessage += OnClientMessage;
            _server.Error += OnError;
            _server.Start();
            while (KeepRunning)
            {
            }
            _server.Stop();
        }

        private void OnClientConnected(NamedPipeConnection<string, string> connection)
        {
            Console.WriteLine($"Client {connection.Id} is now connected!");
            connection.PushMessage($"Welcome {connection.Name}");
        }

        private void OnClientDisconnected(NamedPipeConnection<string, string> connection)
        {
            Console.WriteLine($"Client {connection.Id} disconnected" );
        }

        private void OnClientMessage(NamedPipeConnection<string, string> connection, string message)
        {
            //_server object has the PUBLISHING feature
            _server.PushMessage($"<<PUBLISH MESSAGE!!! Client {connection.Id} says: {message}>>");
        }

        private void OnError(Exception exception)
        {
            Console.Error.WriteLine($"ERROR: {exception}");
        }
    }
}
