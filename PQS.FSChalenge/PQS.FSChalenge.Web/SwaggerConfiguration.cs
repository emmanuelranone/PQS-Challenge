using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQS.FSChalenge.Web
{
    public class SwaggerConfiguration
    {
        /// <summary>
        /// <para>Foo API v1</para>
        /// </summary>
        public const string EndpointDescription = "Foo API v1";

        /// <summary>
        /// <para>/swagger/v1/swagger.json</para>
        /// </summary>
        public const string EndpointUrl = "/swagger/v1/swagger.json";

        /// <summary>       
        /// </summary>
        public const string ContactName = "Emmanuel Ranone";

        /// <summary>       
        /// </summary>
        public static Uri ContactUrl =  new Uri("https://www.linkedin.com/in/emmanuel-ranone-615aa03b/");
        

        /// <summary>
        /// <para>v1</para>
        /// </summary>
        public const string DocNameV1 = "v1";

        /// <summary>
        /// <para>PQS Challenge</para>
        /// </summary>
        public const string DocInfoTitle = "PQS Challenge";

        /// <summary>
        /// <para>v1</para>
        /// </summary>
        public const string DocInfoVersion = "v1";

        /// <summary>
        /// <para>PQS Challenge - Desafío Full Stack</para>
        /// </summary>
        public const string DocInfoDescription = "PQS Challenge - Desafío Full Stack";
    }
}
