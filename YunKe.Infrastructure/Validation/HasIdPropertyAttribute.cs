using System;
using System.Linq;

namespace YunKe.Infrastructure.Validation
{
    /// <summary>
    /// 使用该标记以表明对应参数对象必须含有 Id 属性。
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Parameter)]
    public class HasIdPropertyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the identifier property.
        /// </summary>
        /// <value>
        /// The name of the identifier property.
        /// </value>
        public string IdPropertyName { get; set; } = "Id";

        public HasIdPropertyAttribute()
        {

        }

        public bool Validate(string parameterName, Type type)
        {
            var isOk = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Any(x => x.Name.Equals(IdPropertyName));

            if (!isOk)
            {
                throw new ActionParameterValidationException(parameterName, $"参数：{parameterName} 类型： {type.Name} 不包含 {IdPropertyName} 属性。");
            }

            return isOk;
        }
    }
}
