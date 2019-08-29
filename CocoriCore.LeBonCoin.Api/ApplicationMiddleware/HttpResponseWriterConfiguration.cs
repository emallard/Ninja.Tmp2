﻿using CocoriCore;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CocoriCore.LeBonCoin.Api
{
    public static class HttpResponseWriterConfiguration
    {
        public static HttpResponseWriterOptions Options()
        {
            var builder = new HttpResponseWriterOptionsBuilder();
            builder.For<FileResponse>().Call<HttpResponseWriterFileHandler>();
            //builder.For<IODataResponse>().Call<HttpResponseWriterODataHandler>();
            builder.For<object>().Call<HttpResponseWriterDefaultHandler>();
            return builder.Options;
        }
    }
}
