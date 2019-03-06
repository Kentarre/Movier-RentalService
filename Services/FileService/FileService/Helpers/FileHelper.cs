using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Common.DataTypes.Dto;
using Common.Redis;
using PdfSharpCore.Fonts;
using VetCV.HtmlRendererCore.PdfSharpCore;

namespace FileService.Helpers
{
    public static class FileHelper
    {
        private static RedisProxy rProxy => Redis.Get();

        private static string BodyTemplate => @"
        <h1>Order nr {orderNr}, {name}</h1>
        <p>Created on {createdOn}</p>
        <p>
            Rentals:
        </p>
            <table width=""100%"" border=""1"">
                <tr>
                    <th></th>
                    <th align=""left"">Title</th>
                    <th align=""left"">Period</th>
                    <th align=""left"">Price</th>
                </tr>
                {item}
            </table>";

        private static string ItemTemplate => @"  
        <tr>
            <td>{nr}</td>
            <td>{title}</td>
            <td>{period}</td>
            <td>{price}</td>
        </tr>";

        public static byte[] CreateInvoice(User user, List<Rent> rentals)
        {
            var rentItems = string.Empty;

            foreach (var item in rentals)
            {
                var film = rProxy.Get<Film>(item.FilmId);

                rentItems += ItemTemplate.Replace("{title}", film.Title)
                    .Replace("{period}", $"{item.ActiveFrom} - {item.ActiveTo}")
                    .Replace("{price}", $"{item.Price} Eur");
            }

            var body = BodyTemplate.Replace("{orderNr}", rentals.First().OrderId.ToString())
                .Replace("{name}", $"{user.Name} {user.Surname}")
                .Replace("{createdOn}", rentals.First().ActiveFrom.ToString(CultureInfo.InvariantCulture))
                .Replace("{item}", rentItems);

            return CreatePdf(body);
        }

        private static byte[] CreatePdf(string html)
        {
            byte[] result;

            using (var ms = new MemoryStream())
            {
                var doc = PdfGenerator.GeneratePdf(html, PdfSharpCore.PageSize.A4);
                doc.Save(ms);
                result = ms.ToArray();
            }

            return result;
        }
    }
}
