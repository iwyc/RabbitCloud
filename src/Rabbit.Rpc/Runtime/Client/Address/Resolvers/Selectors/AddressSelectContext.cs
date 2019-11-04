using Rabbit.Rpc.Address;
using System.Collections.Generic;

namespace Rabbit.Rpc.Runtime.Client.Address.Resolvers.Implementation.Selectors
{
    /// <summary>
    /// 地址选择上下文。
    /// </summary>
    public class AddressSelectContext
    {
        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor Descriptor { get; set; }

        /// <summary>
        /// 服务可用地址。
        /// </summary>
        public IEnumerable<AddressModel> Address { get; set; }
    }
}