using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Output
{
    public class ApiResponse
    {
        /// <summary>
        /// Başarısız işlemler için hata kodu. Başarılı işlemlerde 0
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// True ise işlem başarılıdır.
        /// </summary>
        public bool Ok { get; set; }

        /// <summary>
        /// İşlem yapılan kaydın Id değeri
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sayfa numarası
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Sayfada gönderilecek kayıt sayısı
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// İşlem açıklaması.
        /// Başarısız veya uyarı olan işlemlerde hata veya uyarı mesajını barındırır.
        /// Başarılı işlemlerde genellikle null değerini alır.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gönderilen datalar
        /// </summary>
        public object Data { get; set; }

        public ApiResponse(bool ok, int code, int page, int pageSize, string message, object data)
        {
            Code = code;
            Ok = ok;
            Page = page;
            PageSize = pageSize;
            Message = message;
            Data = data;
        }


    }
}
