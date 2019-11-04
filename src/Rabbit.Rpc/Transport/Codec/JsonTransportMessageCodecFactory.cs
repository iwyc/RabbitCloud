﻿namespace Rabbit.Rpc.Transport.Codec.Implementation
{
    public class JsonTransportMessageCodecFactory : ITransportMessageCodecFactory
    {
     

        private readonly ITransportMessageEncoder _transportMessageEncoder = new JsonTransportMessageEncoder();
        private readonly ITransportMessageDecoder _transportMessageDecoder = new JsonTransportMessageDecoder();

    

    
        /// <summary>
        /// 获取编码器。
        /// </summary>
        /// <returns>编码器实例。</returns>
        public ITransportMessageEncoder GetEncoder()
        {
            return _transportMessageEncoder;
        }

        /// <summary>
        /// 获取解码器。
        /// </summary>
        /// <returns>解码器实例。</returns>
        public ITransportMessageDecoder GetDecoder()
        {
            return _transportMessageDecoder;
        }

    }
}