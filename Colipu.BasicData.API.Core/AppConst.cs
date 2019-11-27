using System;
using System.Collections.Generic;
using System.Linq;

namespace BangBangFuli.H5.API.Core
{
    public class AppConst
    {
        /// <summary>
        /// 系统种子编号 默认步长
        /// </summary>
        public static int DefaultStepValue = 1;

        /// <summary>
        /// 系统种子编号 默认起始位置
        /// </summary>
        public static int DefaultStartMaxId = 10000;

        /// <summary>
        /// 系统默认简单密码
        /// </summary>
        public static string DefaultSmiplePassword = "123456";

        /// <summary>
        /// 特殊客户名称前缀
        /// </summary>
        public static string SpecialCustomerNamePrefix = "【OD】";

        /// <summary>
        /// 是否
        /// </summary>
        public struct YNStruct
        {
            /// <summary>
            /// 是
            /// </summary>
            public static readonly string Yes = "Y";

            /// <summary>
            /// 否
            /// </summary>
            public static readonly string No = "N";
        }

        /// <summary>
        /// 状态
        /// </summary>
        public struct StatusStruct
        {
            /// <summary>
            /// 有效
            /// </summary>
            public static readonly string Active = "A";

            /// <summary>
            /// 无效
            /// </summary>
            public static readonly string Passive = "P";

            /// <summary>
            /// 删除
            /// </summary>
            public static readonly string Delete = "X";
        }

        /// <summary>
        /// 登录方式
        /// </summary>
        public struct LoginType
        {
            /// <summary>
            /// 用户名
            /// </summary>
            public static readonly string User = "U";

            /// <summary>
            /// 邮箱
            /// </summary>
            public static readonly string Email = "E";

            /// <summary>
            /// 手机
            /// </summary>
            public static readonly string Mobile = "M";

            /// <summary>
            /// 微信
            /// </summary>
            public static readonly string WeChat = "W";

            /// <summary>
            /// 编号
            /// </summary>
            public static readonly string LoginId = "L";

            public static List<string> GetValues()
            {
                Type structType = typeof(LoginType);

                return structType.GetFields().Select(x => x.GetValue(x.Name).ToString()).ToList();
            }
        }

        /// <summary>
        /// 渠道类型
        /// </summary>
        public struct ChannelType
        {
            /// <summary>
            /// B2C
            /// </summary>
            public static readonly int B2C = 1;

            /// <summary>
            /// B2B
            /// </summary>
            public static readonly int B2B = 2;

            /// <summary>
            /// SMB
            /// </summary>
            public static readonly int SMB = 3;

            public static List<int> GetValues()
            {
                Type structType = typeof(ChannelType);

                return structType.GetFields().Select(x => (int)x.GetValue(x.Name)).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public struct ResponseCode
        {
            /// <summary>
            /// 成功
            /// </summary>
            public static readonly string Success = "SUCCESS";

            /// <summary>
            /// 未知异常
            /// </summary>
            public static readonly string Unknown = "Unknown";

            /// <summary>
            /// 服务器处理异常
            /// </summary>
            public static readonly string ServerError = "SERVER_ERROR";

            /// <summary>
            /// 非法参数
            /// </summary>
            public static readonly string IllegalParameter = "ILLEGAL_PARAMETER";

            /// <summary>
            /// 业务不允许
            /// </summary>
            public static readonly string UnallowedBusiness = "UNALLOWED_BUSINESS";
        }

        /// <summary>
        /// 服务等级
        /// </summary>
        public static readonly Dictionary<string, string> ShipTypeLevels = new Dictionary<string, string>
        {
            { "O", "平邮" },
            { "E", "快递" },
            { "U","加急快递"}
        };
    }
}
