﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaVision.Core.Models.Common
{
    public class ValidateImageFileAttribute : RequiredAttribute
    {
        private const int MaxFileLengthInBytes = 1048576; // = (1 * 1024 * 1024) = 1 MB;

        public override bool IsValid(object value)
        {
            // Represents the file sent with the HttpRequest
            IFormFile file = value as IFormFile;

            if (file == null)
            {
                return false;
            }

            if (file.Length > MaxFileLengthInBytes)
            {
                return false;
            }

            // Check the image mime types
            if (file.ContentType.ToLower() != "image/jpg"
                && file.ContentType.ToLower() != "image/jpeg"
                && file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            return true;
        }
    }
}
