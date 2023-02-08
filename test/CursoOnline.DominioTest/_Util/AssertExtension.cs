using System;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertExtension
    {

        /// <summary>
        /// Método de extensão para a classe ArgumentException
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="mensagem"></param>
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false, $"Esperava a mensagem '{mensagem}'");
            }
        }

    }
}
