using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamedPipeWrapper;

namespace WindowsPublishSubscribe
{
    public class Client
    {
        private string _pipelineName;
        private NamedPipeClient<string> _client;
        public Client(string pipelineName= "DefaultPipelineName")
        {
            if (pipelineName != "") _pipelineName = pipelineName;

             _client = new NamedPipeClient<string>(_pipelineName);
            _client.ServerMessage += OnServerMessage;
            _client.Error += OnError;
            _client.Disconnected += OnDisconnected;
            _client.Start();
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                _client.PushMessage(userInput);
            } while (userInput != "stop");
            _client.Stop();

        }

        private void OnServerMessage(NamedPipeConnection<string, string> connection, string message)
        {
            //client subscribe to server
            Console.WriteLine($"Server says: {message}");
        }

        private void OnError(Exception exception)
        {
            Console.Error.WriteLine($"ERROR: {exception}");
        }
        private void OnDisconnected(NamedPipeConnection<string, string> connection)
        {
            Environment.Exit(0);
        }

    }
}
