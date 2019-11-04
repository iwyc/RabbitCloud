using System.Net;

namespace Rabbit.Rpc.Address
{
    /// <summary>
    /// ip��ַģ�͡�
    /// </summary>
    public sealed class IpAddressModel : AddressModel
    {
      

        /// <summary>
        /// ��ʼ��һ���µ�ip��ַģ��ʵ����
        /// </summary>
        public IpAddressModel()
        {
        }

        /// <summary>
        /// ��ʼ��һ���µ�ip��ַģ��ʵ����
        /// </summary>
        /// <param name="ip">ip��ַ��</param>
        /// <param name="port">�˿ڡ�</param>
        public IpAddressModel(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }



        /// <summary>
        /// ip��ַ��
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// �˿ڡ�
        /// </summary>
        public int Port { get; set; }

      

        /// <summary>
        /// �����ս�㡣
        /// </summary>
        /// <returns></returns>
        public override EndPoint CreateEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(Ip), Port);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Ip}:{Port}";
        }

    }
}