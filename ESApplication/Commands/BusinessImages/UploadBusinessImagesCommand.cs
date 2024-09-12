﻿
using ESApplication.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ESApplication.Commands.BusinessImages
{
    public class UploadBusinessImagesCommand : IRequest<Response<string>>
    {
        public Int64 BusinessId { get; set; }
        public Int64 UserId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public int type { get; set; }
        /// <summary>
        /// Images to upload for feed post card
        /// </summary>
        public List<string> ImageNames { get; set; }               

    }
}
