/*
 * The MIT License
 *
 * Copyright 2019 Rob Garcia at rgarcia@rgprogramming.com.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickMeds.Common {
    public static class AppFunctions {
        /// <summary>
        /// Download the database from GitHub
        /// Thanks to Daxton47 at https://forums.xamarin.com/discussion/138266/how-to-hit-an-url-to-download-a-file
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        public static async Task<byte[]> DownloadFileAsync(string fileUrl) {
            var _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };

            try {
                using (var httpResponse = await _httpClient.GetAsync(fileUrl)) {
                    if (httpResponse.StatusCode == HttpStatusCode.OK) {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else {
                        // Url is Invalid
                        return null;
                    }
                }
            }
            catch (Exception) {
                //Handle Exception
                return null;
            }
        }
    }
}
