﻿using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using Rabbit.Rpc.Messages;
using Rabbit.Rpc.Transport;
using Rabbit.Rpc.Transport.Codec;
using System;
using System.Threading.Tasks;

namespace Rabbit.Transport.DotNetty
{
    /// <summary>
    /// 基于DotNetty的消息发送者基类。
    /// </summary>
    public abstract class DotNettyMessageSender
    {
        private readonly ITransportMessageEncoder _transportMessageEncoder;

        protected DotNettyMessageSender(ITransportMessageEncoder transportMessageEncoder)
        {
            _transportMessageEncoder = transportMessageEncoder;
        }

        protected IByteBuffer GetByteBuffer(TransportMessage message)
        {
            var data = _transportMessageEncoder.Encode(message);

            var buffer = Unpooled.Buffer(data.Length, data.Length);
            return buffer.WriteBytes(data);
        }
    }

    /// <summary>
    /// 基于DotNetty客户端的消息发送者。
    /// </summary>
    public class DotNettyMessageClientSender : DotNettyMessageSender, IMessageSender, IDisposable
    {
        private readonly IChannel _channel;

        public DotNettyMessageClientSender(ITransportMessageEncoder transportMessageEncoder, IChannel channel) : base(transportMessageEncoder)
        {
            _channel = channel;
        }


        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Task.Run(async () =>
            {
                await _channel.DisconnectAsync();
            }).Wait();
        }

        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            await _channel.WriteAsync(buffer);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            await _channel.WriteAndFlushAsync(buffer);
        }
    }

    /// <summary>
    /// 基于DotNetty服务端的消息发送者。
    /// </summary>
    public class DotNettyServerMessageSender : DotNettyMessageSender, IMessageSender
    {
        private readonly IChannelHandlerContext _context;

        public DotNettyServerMessageSender(ITransportMessageEncoder transportMessageEncoder, IChannelHandlerContext context) : base(transportMessageEncoder)
        {
            _context = context;
        }


        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public Task SendAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            return _context.WriteAsync(buffer);
        }

        /// <summary>
        /// 发送消息并清空缓冲区。
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public Task SendAndFlushAsync(TransportMessage message)
        {
            var buffer = GetByteBuffer(message);
            return _context.WriteAndFlushAsync(buffer);
        }
    }
}