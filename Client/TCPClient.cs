using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace ViTrader.Client
{
    enum Type
    {
        LOGIN,
        REGISTER,
        NEXT_USER_ID
    }

    enum Errors
    {
        INACTIVE_ACCOUNT = -1,
        WRONG_INFO = -2,
        USERNAME_EXISTS = -3,
        EMAIL_EXISTS = -4,
        UNKNOWN = -5,
        MAIL_NOT_SENT = -6
    }

    class TCPClient
    {
        TcpClient client;

        public TCPClient()
        {
            string fileName = "serverconfig.json";
            string jsonString = File.ReadAllText(fileName);

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                string address = root.GetProperty("ServerAddress").GetString();
                string port = root.GetProperty("Port").GetString();

                client = new TcpClient(address, int.Parse(port));
            }
        }

        public bool Login(string userName, string password, out int id)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] typeBytes = BitConverter.GetBytes((int)Type.LOGIN);
                byte[] nameBytes = Encoding.UTF8.GetBytes(userName);
                byte[] nameLenBytes = BitConverter.GetBytes(nameBytes.Length);

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] passwordLenBytes = BitConverter.GetBytes(passwordBytes.Length);

                byte[] toWrite = typeBytes
                    .Concat(nameLenBytes)
                    .Concat(nameBytes)
                    .Concat(passwordLenBytes)
                    .Concat(passwordBytes).ToArray();

                stream.Write(toWrite, 0, toWrite.Length);

                byte[] returnBytes = new byte[4];

                stream.Read(returnBytes, 0, 4);
                id = BitConverter.ToInt32(returnBytes, 0);

                if (id < 1)
                    return false;

                return true;
            }
        }

        public bool Register(string userName, string password, string emailAddress, out int id)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] typeBytes = BitConverter.GetBytes((int)Type.REGISTER);
                byte[] nameBytes = Encoding.UTF8.GetBytes(userName);
                byte[] nameLenBytes = BitConverter.GetBytes(nameBytes.Length);

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] passwordLenBytes = BitConverter.GetBytes(passwordBytes.Length);

                byte[] emailBytes = Encoding.UTF8.GetBytes(emailAddress);
                byte[] emailLenBytes = BitConverter.GetBytes(emailBytes.Length);

                byte[] toWrite = typeBytes
                    .Concat(nameLenBytes)
                    .Concat(nameBytes)
                    .Concat(passwordLenBytes)
                    .Concat(passwordBytes)
                    .Concat(emailLenBytes)
                    .Concat(emailBytes).ToArray();

                stream.Write(toWrite, 0, toWrite.Length);

                byte[] returnBytes = new byte[4];

                stream.Read(returnBytes, 0, 4);
                id = BitConverter.ToInt32(returnBytes, 0);

                if (id < 1)
                    return false;

                return true;
            }
        }
    }
}
