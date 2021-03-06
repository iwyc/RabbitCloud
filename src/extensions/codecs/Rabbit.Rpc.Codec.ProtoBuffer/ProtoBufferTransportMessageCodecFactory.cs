﻿using Rabbit.Rpc.Transport.Codec;

namespace Rabbit.Rpc.Codec.ProtoBuffer
{
    public class ProtoBufferTransportMessageCodecFactory : ITransportMessageCodecFactory
    {

        private readonly ITransportMessageEncoder _transportMessageEncoder = new ProtoBufferTransportMessageEncoder();
        private readonly ITransportMessageDecoder _transportMessageDecoder = new ProtoBufferTransportMessageDecoder();
               
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