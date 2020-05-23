///<remarks> 
/// -Cesar I. Mendoza (aberuwu)
/// File: BotPost.cs
/// Purpose: Contains classes and methods for the posting match results
/// to Facebook using the Facebook Graph API
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using System.Threading;
using System.Collections;

namespace DDCBot6000GUI
{
    ///<remarks> 
    /// BotPost
    /// This class contains methods for "manually" posting to facebook using the endpoint        
    /// </remarks>
    public class BotPost
    {
        private const string FB_IMAGE_ADDRESS = "https://graph.facebook.com/v6.0/me/photos";
        private const string FB_BASE_ADDRESS = "https://graph.facebook.com/";
        public const string FB_PAGE_ID = "107789687591192";
        private string fB_ACCESS_TOKEN;

        public string FB_ACCESS_TOKEN { get => fB_ACCESS_TOKEN; set => fB_ACCESS_TOKEN = value; }


        ///<remarks> 
        /// PublishMessage
        /// This async method takes in a string and publishes it to facebook manually
        /// using the Facebook endpoint
        /// </remarks>
        public async Task<string> PublishMessage(string message)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(FB_BASE_ADDRESS);

                var parametters = new Dictionary<string, string>
                {
                    { "access_token", FB_ACCESS_TOKEN },
                    { "message", message }
                };
                var encodedContent = new FormUrlEncodedContent(parametters);
                var result = await httpClient.PostAsync($"{FB_PAGE_ID}/feed", encodedContent);
                var msg = result.EnsureSuccessStatusCode();
                return await msg.Content.ReadAsStringAsync();
            }
        }

        ///<remarks> 
        /// PublishImageAndMessageManual
        /// This aync method take in a string and image url path that posts both a caption
        /// and image to facebook manually using the Facebook endpoint
        /// </remarks>
        public async Task<string> PublishImageAndMessageManual(string caption, string image)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(FB_IMAGE_ADDRESS);

                var parametters = new Dictionary<string, string>
                {
                    { "access_token", FB_ACCESS_TOKEN },
                    { "message", caption }
                };
                var encodedContent = new FormUrlEncodedContent(parametters);
                var result = await httpClient.PostAsync($"?{image}&caption={caption}&access_token={FB_ACCESS_TOKEN}", encodedContent);
                var msg = result.EnsureSuccessStatusCode();
                return await msg.Content.ReadAsStringAsync();
            }
        }


        ///<remarks> 
        /// postToFbImage
        /// This class method takes 4 parameters for page ID, access token, file path and caption
        /// Uploads a local image and caption to Facebook using the Graph API wrapper functions
        /// </remarks>
        public string postToFbImage(string id, string accessToken, string filePath, string caption)
        {
            var mediaObject = new FacebookMediaObject
            {
                FileName = System.IO.Path.GetFileName(filePath),
                ContentType = "image/jpeg"
            };

            mediaObject.SetValue(System.IO.File.ReadAllBytes(filePath));

            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Post(id + "/photos", new Dictionary<string, object>
                                   {
                                       { "source", mediaObject },
                                       { "message", caption }
                                   });

                var postId = (string)result["id"];

                frmMain frm = new frmMain();
                frm.rctConsoleOutput.AppendText(Environment.NewLine + "DDCBot600 - Post completed succesfully! uwu");
                return postId;
            }
            catch (FacebookApiException ex)
            {
                frmMain frm = new frmMain();
                frm.rctConsoleOutput.AppendText(Environment.NewLine + "\nAn error ocurred, try again or try another token! UnU " +
                    "\n\n-------------Facebook Exception Details-------------");
                throw;
            }
        }


        ///<remarks> 
        /// validateToken
        /// This method debugs argument string token
        /// Returns true if token is valid
        /// Returns false if token is not valid
        /// </remarks>
        public bool validateToken(string token)
        {
            try
            {
                var fb = new FacebookClient(token);
                frmMain.apiResponse = fb.Get($"/debug_token?input_token={token}").ToString();
                return true;
            }
            catch(FacebookApiException)
            {
                return false;
            }
        }

    }
}
