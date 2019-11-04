using Microsoft.Extensions.DependencyInjection;
using System;


namespace Rabbit.Rpc
{
    /// <summary>
    /// 默认的Rpc服务构建者。
    /// </summary>
    internal sealed class RpcBuilder : IRpcBuilder
    {
        public RpcBuilder(IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            Services = services;
        }

        /// <summary>
        /// 服务集合。
        /// </summary>
        public IServiceCollection Services { get; }

    }
}